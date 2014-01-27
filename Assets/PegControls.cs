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

		Camera.main.transform.position = new Vector3(5*numPegs - 15, 10 + numPegs, -5*numPegs - 15);
		for (int i = 0; i < numPegs; i++) {
			Peg newPeg  = ((Transform) Instantiate(pegFab, new Vector3(i*10 - 10, 4,0), Quaternion.identity)).GetComponent<Peg>();
			newPeg.transform.parent = this.transform;
			newPeg.numDisks = numDisks;
			if(i < numTowers) {
				newPeg.MakeDisks();
				newPeg.startingPeg = true;
				newPeg.renderer.material.color = Color.yellow;
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
		GUI.Label (new Rect (Screen.width / 2 + 150, Screen.height / 4 - 30, 150, 40), "Number of Disks");
		numDisks = Mathf.RoundToInt( GUI.HorizontalSlider (new Rect (Screen.width / 2 + 150, Screen.height / 4, 100, 40), numDisks, 1, 8));
		GUI.Label (new Rect (Screen.width / 2 - 250, Screen.height / 4 - 30, 150, 40), "Number of Towers");
		numTowers = Mathf.RoundToInt( GUI.HorizontalSlider (new Rect (Screen.width / 2 -250,  Screen.height / 4, 100, 40), numTowers, 1, 3));
		GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 4 - 30, 150, 40), "Number of Pegs");
		numPegs =  Mathf.Max(Mathf.RoundToInt( GUI.HorizontalSlider (new Rect (Screen.width / 2 - 50, Screen.height / 4, 100, 40), numPegs, 3, 9)), numTowers*2);

		if (GUI.changed) {
			print(numPegs);
			Peg.completed = 0;
			DestroyDisks();
			InitializeGame ();
		}
	}
}
