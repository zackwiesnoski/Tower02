using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	
	// How to play a sound:
	
	// example: StartCoroutine (SoundManager.PlaySound(Resources.Load("Sounds/pop")as AudioClip));
	
	
	
	// the sound object
	public GameObject Soundobject;
	
	// global sound volume
	public static float Soundvolume = 1.0f;
	
	// global Music volume
	public static float Musicvolume = 1.0f;
	
	//Sound manager
	static GameObject Soundmanager;
	static AudioSource Aud;
	//static AudioSource Aud2;
	
	// dont Destroy
	void Awake() {
        DontDestroyOnLoad(this);
		Soundobject = Resources.Load("SoundPlayer") as GameObject;
    }
	
	// Use this for initialization
	void Start () {
	Soundmanager = GameObject.Find("Sound Manager");
	//PlayMusic(Resources.Load("Sounds/MusicLoop") as AudioClip);

	Aud = Soundmanager.GetComponent<AudioSource>();
	//Aud2 = Soundmanager.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		Aud.volume = Musicvolume;
		//Aud2.volume = Musicvolume;
	}
	
	public static IEnumerator PlaySound(AudioClip clip){
		
		AudioSource SoundAudi;
		
		GameObject clone;
		
		
		clone = Instantiate(Resources.Load("SoundPlayer") as GameObject) as GameObject;	
		SoundAudi = clone.GetComponent<AudioSource>();
		SoundAudi.volume = Soundvolume;
		SoundAudi.clip = clip;
		SoundAudi.Play();
		
		yield return new WaitForSeconds(clip.length);
		Destroy(clone);
		
	}
	
	public static void PlayMusic(AudioClip thisclip){
		
		print (thisclip);
		Aud.clip = thisclip;
		Aud.loop=true;
		Aud.Play();
		
	}

	
}
