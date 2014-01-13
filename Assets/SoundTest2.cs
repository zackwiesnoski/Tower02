using UnityEngine;
using System.Collections;

public class SoundTest2 : MonoBehaviour {

void Start () {
	StartCoroutine("SoundTest");
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	IEnumerator SoundTest (){
	yield return new WaitForSeconds (5.2f);
	SoundManager.PlaySound(Resources.Load("Sounds/MusicLoop")as AudioClip);
	print ("start SoundTest");
	StartCoroutine("SoundTest");
	}
}
