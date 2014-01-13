using UnityEngine;
using System.Collections;

public class SoundTestScipt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	StartCoroutine("SoundTest");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator SoundTest (){
	yield return new WaitForSeconds (1);
	StartCoroutine (SoundManager.PlaySound(Resources.Load("Sounds/pop")as AudioClip));
	print ("start SoundTest");
	StartCoroutine("SoundTest");
	}
}
