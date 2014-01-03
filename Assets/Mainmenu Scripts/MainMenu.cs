using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	// GUI style for the main menu
	new public GUIStyle Buttonstyle;
	
	//screen width offset for gui elements
	new int MenuoffSetX = 0;
	
	
	//GUI Texture indicators of sound and music on/off
	new public Texture Musicindi;
	new public Texture Soundindi;
	new bool MusicisOn;
	new bool SoundifOn;
	
	
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	void OnGUI() {
		// the three main buttons on the menu
		if (GUI.Button (new Rect((Screen.width/1.8f+MenuoffSetX),Screen.height/5,Screen.width/3,Screen.height/7), "Play",Buttonstyle)){
		
		Debug.Log("Loadlevel");
		}
		
		if (GUI.Button (new Rect((Screen.width/1.8f+MenuoffSetX),Screen.height/2.3f,Screen.width/3,Screen.height/7), "Options",Buttonstyle)){
			MenuoffSetX = Screen.width;
		}
		
		if (GUI.Button (new Rect((Screen.width/1.8f+MenuoffSetX),Screen.height/1.5f,Screen.width/3,Screen.height/7), "Credits",Buttonstyle)){
			MenuoffSetX = -Screen.width;	
		}
		
		// GUI elements for the OPTIONS screen
		
		if (GUI.Button(new Rect((Screen.width + Screen.width/5) - MenuoffSetX, Screen.height/4, Screen.width/6,Screen.height/6),"Sound", Buttonstyle)){
		
			ChangeMusic();
			
		}
		
		
		if (GUI.Button(new Rect((Screen.width + Screen.width/5) - MenuoffSetX, Screen.height/2, Screen.width/6,Screen.height/6),"Music", Buttonstyle)){
		
			ChangeSound();
			
		}
		
		if (GUI.Button(new Rect((Screen.width + Screen.width/2) - MenuoffSetX, Screen.height/1.2f, Screen.width/8,Screen.height/8),"Back", Buttonstyle)){
			MenuoffSetX = 0;
		}
		
		GUI.Box(new Rect((Screen.width + Screen.width/1.3f) - MenuoffSetX, Screen.height/4,Screen.width/6,Screen.height/6),Musicindi);
   
		GUI.Box(new Rect((Screen.width + Screen.width/1.3f) - MenuoffSetX, Screen.height/2,Screen.width/6,Screen.height/6),Soundindi);
	}
	
	void ChangeMusic(){
	if(MusicisOn == true){
	Musicindi = Resources.Load("X") as Texture;
	MusicisOn = false;
		}
	else{
	Musicindi = Resources.Load("check") as Texture;		
	MusicisOn = true;
		}
	}
	
	
	void ChangeSound(){
	if(SoundifOn == true){
	Soundindi = Resources.Load("X") as Texture;
	SoundifOn = false;
		}
	else{
	Soundindi = Resources.Load("check") as Texture;		
	SoundifOn = true;
		}
	}
}
