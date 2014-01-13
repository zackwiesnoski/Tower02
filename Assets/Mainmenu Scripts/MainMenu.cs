using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	// GUI style for the main menu
	new public GUIStyle Buttonstyle;
	
	//screen width offset for gui elements
	new float MenuoffSetX = 0;
	new float Targetval;
	
	
	//GUI Texture indicators of sound and music on/off
	new public Texture Musicindi;
	new public Texture Soundindi;
	new bool MusicisOn = true;
	new bool SoundifOn = true;
	
	
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
	MenuoffSetX = iTween.FloatUpdate(MenuoffSetX, Targetval, 3);
	}
	
	
	// all GUI elements
	void OnGUI() {
		// the three main buttons on the menu
		if (GUI.Button (new Rect((Screen.width/1.8f+MenuoffSetX),Screen.height/5,Screen.width/3,Screen.height/7), "Play",Buttonstyle)){
		
		Application.LoadLevel("firstScene");
		}
		
		if (GUI.Button (new Rect((Screen.width/1.8f+MenuoffSetX),Screen.height/2.3f,Screen.width/3,Screen.height/7), "Options",Buttonstyle)){
			Targetval = Screen.width;
			StartCoroutine (SoundManager.PlaySound(Resources.Load("Sounds/pop")as AudioClip));
		}
		
		if (GUI.Button (new Rect((Screen.width/1.8f+MenuoffSetX),Screen.height/1.5f,Screen.width/3,Screen.height/7), "Credits",Buttonstyle)){
			Targetval = -Screen.width;	
			StartCoroutine (SoundManager.PlaySound(Resources.Load("Sounds/pop")as AudioClip));
		}
		
		// GUI elements for the OPTIONS screen
		
		if (GUI.Button(new Rect((Screen.width + Screen.width/5) - MenuoffSetX, Screen.height/4, Screen.width/6,Screen.height/6),"Sound", Buttonstyle)){
		
			ChangeSound();
			StartCoroutine (SoundManager.PlaySound(Resources.Load("Sounds/pop")as AudioClip));
		}
		
		
		if (GUI.Button(new Rect((Screen.width + Screen.width/5) - MenuoffSetX, Screen.height/2, Screen.width/6,Screen.height/6),"Music", Buttonstyle)){
		
			ChangeMusic();
			StartCoroutine (SoundManager.PlaySound(Resources.Load("Sounds/pop")as AudioClip));
		}
		
		if (GUI.Button(new Rect((Screen.width + Screen.width/2) - MenuoffSetX, Screen.height/1.2f, Screen.width/8,Screen.height/8),"Back", Buttonstyle)){
			Targetval = 0;
			StartCoroutine (SoundManager.PlaySound(Resources.Load("Sounds/pop")as AudioClip));
		}
		
		GUI.Box(new Rect((Screen.width + Screen.width/1.3f) - MenuoffSetX, Screen.height/4,Screen.width/6,Screen.height/6),Soundindi);
   
		GUI.Box(new Rect((Screen.width + Screen.width/1.3f) - MenuoffSetX, Screen.height/2,Screen.width/6,Screen.height/6),Musicindi);
		
		//GUI elements for credits screen 

	
		GUI.Box(new Rect((Screen.width/4 + Screen.width)+MenuoffSetX,Screen.height/4,Screen.width/2,Screen.height/2),"Zack, Thatcher and John");
	
		if (GUI.Button(new Rect((Screen.width/2 - Screen.width) - MenuoffSetX, Screen.height/1.2f, Screen.width/8,Screen.height/8),"Back", Buttonstyle)){
			StartCoroutine (SoundManager.PlaySound(Resources.Load("Sounds/pop")as AudioClip));
			Targetval = 0;
		}
	}
	

	
	void ChangeMusic(){
	if(MusicisOn == true){
	Musicindi = Resources.Load("X") as Texture;
	SoundManager.Musicvolume = 0.0f;
	MusicisOn = false;
		}
	else{
	Musicindi = Resources.Load("check") as Texture;		
	SoundManager.Musicvolume = 1.0f;	
	MusicisOn = true;
		}
	}
	
	
	void ChangeSound(){
	if(SoundifOn == true){
	Soundindi = Resources.Load("X") as Texture;
	SoundManager.Soundvolume = 0.0f;
	SoundifOn = false;
		}
	else{
	Soundindi = Resources.Load("check") as Texture;
	SoundManager.Soundvolume = 1.0f;	
	SoundifOn = true;
		}
	}
	
//	IEnumerator ChangeMenuOffSet(float Targetval){
//		print (MenuoffSetX);
//		
//		MenuoffSetX = iTween.FloatUpdate(MenuoffSetX, Targetval, 3);
//		yield return new WaitForSeconds(2);
//			
//	}
	
}
