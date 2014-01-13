using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PegControls : MonoBehaviour {


	public Stack<DiskControls> disks = new Stack<DiskControls> ();
	public bool start, destination;
	public static int numDisks = 3;
	static PegControls selected = null;
	public Transform diskFab;

	void Start () {
		if (start) {
			for(int i = 0; i < numDisks; i++) {
				DiskControls newDisk  = ((Transform) Instantiate(diskFab, new Vector3(transform.position.x,i - 0.5f,0), Quaternion.identity)).GetComponent<DiskControls>();
				newDisk.setSize(numDisks+1 - i);
				disks.Push(newDisk);
			}
		}
		foreach (DiskControls dc in gameObject.GetComponentsInChildren<DiskControls>()) {
			disks.Push(dc);
			print (disks.Count);

		}
	}

	void Select() {
		selected = this;
		transform.renderer.material.color = Color.green;
	}

	void DeSelect() {
		selected = null;
		transform.renderer.material.color = Color.gray;
	}
	void OnMouseDown() {
		//if no tower has been selected and this peg is not empty, select this tower
		if (selected == null) {
			if(disks.Count > 0) {
				Select();
			}
		//otherwise, transfer disk from selected peg
		} else {
			Transfer ();
			selected.DeSelect ();
		}
	}

	//Moves a disk from selected peg to this one.
	void Transfer() {
		if (selected.disks.Count > 0 && selected != this) {
			print ("transfer!");
			if (disks.Count == 0 || selected.disks.Peek ().getSize () < disks.Peek ().getSize ()) {
				DiskControls moved = selected.disks.Pop ();
				disks.Push (moved);
				moved.transform.parent = transform;
				moved.transform.position = new Vector3(transform.position.x,disks.Count-1.5f,0);
				if(disks.Count == numDisks) {
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
	}
}
