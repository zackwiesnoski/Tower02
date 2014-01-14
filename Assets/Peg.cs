using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Peg : MonoBehaviour {

	public Stack<DiskControls> disks = new Stack<DiskControls> ();
	public Transform diskFab; // prefab for instantiating disks
	public bool startingPeg = false;
	static Peg selected;
	public int numDisks;
	static public int completed = 0;


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

	void Transfer() {
		if (selected.disks.Count > 0 && selected != this) {
			if (disks.Count == 0 || selected.disks.Peek ().getSize () < disks.Peek ().getSize ()) {
				if(selected.disks.Count == numDisks && !selected.startingPeg) {
					completed--;
				}
				DiskControls moved = selected.disks.Pop ();
				disks.Push (moved);
				moved.transform.parent = transform;
				moved.transform.position = new Vector3(transform.position.x,disks.Count-1.5f,0);
				if(disks.Count == numDisks && !startingPeg) {
					completed++;
				}
				print (completed);
				if(completed == PegControls.numTowers) {
					completed = 0;
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
	}

	public void Select() {
		selected = this;
		transform.renderer.material.color = Color.green;
	}

	public void DeSelect() {
		selected = null;
		transform.renderer.material.color = Color.white;
	}

	public void MakeDisks() {
		for(int i = 0; i < numDisks; i++) {
			DiskControls newDisk  = ((Transform) Instantiate(diskFab, new Vector3(transform.position.x,i - 0.5f,0), Quaternion.identity)).GetComponent<DiskControls>();
			newDisk.transform.parent = this.transform;
			newDisk.setSize(numDisks+1 - i);
			disks.Push(newDisk);
		}
	}
}
