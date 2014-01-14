using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PegControls : MonoBehaviour {


	public int numDisks = 5; //number of disks per tower
	public int numPegs = 3; //number of pegs
	public static int numTowers = 1; // number of towers
	Peg selected = null; //the currently selected peg
	public Transform pegFab; //prefabs for instantiating pegs

	void Start() {
		InitializeGame ();
	}

	void InitializeGame() {

		for (int i = 0; i < numPegs; i++) {
			Peg newPeg  = ((Transform) Instantiate(pegFab, new Vector3(i*10 - 10, 4,0), Quaternion.identity)).GetComponent<Peg>();
			newPeg.transform.parent = this.transform;
			newPeg.numDisks = numDisks;
			if(i < numTowers) {
				newPeg.MakeDisks();
				newPeg.startingPeg = true;
			}
		}
	}


	void DestroyDisks() {
		foreach (Transform child in transform) {
			//Destroy(child.gameObject);
			DestroyObject(child.gameObject);

		}
	}

	void OnGUI() {
		GUI.Label (new Rect (Screen.width / 2 + 20, Screen.height / 4 - 30, 150, 40), "Number of Disks");
		numDisks = Mathf.RoundToInt( GUI.HorizontalSlider (new Rect (Screen.width / 2, Screen.height / 4, 150, 40), numDisks, 1, 8));
		GUI.Label (new Rect (Screen.width / 2 - 180, Screen.height / 4 - 30, 150, 40), "Number of Pegs");
		numPegs = Mathf.RoundToInt( GUI.HorizontalSlider (new Rect (Screen.width / 2 - 200, Screen.height / 4, 150, 40), numPegs, 3, 9));
		GUI.Label (new Rect (Screen.width / 2 - 380, Screen.height / 4 - 30, 150, 40), "Number of Towers");
		numTowers = Mathf.RoundToInt( GUI.HorizontalSlider (new Rect (Screen.width / 2 -400,  Screen.height / 4, 150, 40), numTowers, 1, 3));

		if (GUI.changed) {
			Peg.completed = 0;
			DestroyDisks();
			InitializeGame ();
		}
	}
}
