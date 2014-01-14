using UnityEngine;
using System.Collections;

public class IngameMenu : MonoBehaviour {
	
	bool Uidisplay = true;
	
	//UI button art
	new public GUIStyle Musicstyle;
	new public GUIStyle Soundstyle;
	new public Texture2D Musicindi;
	new public Texture2D Soundindi;
	
	

	// Use this for initialization
	void Start () {
	if(SoundManager.Soundvolume == 1.0f){
			Soundstyle.normal.background = Resources.Load("Check") as Texture2D;
			}
			else{
			Soundstyle.normal.background = Resources.Load("X") as Texture2D;
				}
		
	if(SoundManager.Musicvolume == 1.0f){
			Musicstyle.normal.background = Resources.Load("Check") as Texture2D;
				}
			else{
			Musicstyle.normal.background = Resources.Load("X") as Texture2D;
				}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnGUI() {
		
		if (Uidisplay == true){
		
		
	if (GUI.Button (new Rect(Screen.width/7, Screen.height/7, Screen.width/10, Screen.height/10), "Menu")){
		
		SoundManager.PlaySound((Resources.Load("Sounds/pop")as AudioClip));
		Application.LoadLevel("Main Menu");
			
		}
			
			
	if (GUI.Button (new Rect(Screen.width/7, Screen.height/4, Screen.width/10, Screen.height/10), "Music", Musicstyle)){
		
		ChangeMusic();
		StartCoroutine (SoundManager.PlaySound(Resources.Load("Sounds/pop")as AudioClip));
		}
			
	if (GUI.Button (new Rect(Screen.width/7, Screen.height/3, Screen.width/10, Screen.height/10), "Sound", Soundstyle)){
		
		ChangeSound();
		StartCoroutine (SoundManager.PlaySound(Resources.Load("Sounds/pop")as AudioClip));
		}
		
	}
		
	}
	
	void ChangeMusic(){
	if(SoundManager.Musicvolume == 1.0f){
	SoundManager.Musicvolume = 0.0f;
	Musicstyle.normal.background = Resources.Load("X") as Texture2D;
		}
	else{
			Musicstyle.normal.background = Resources.Load("Check") as Texture2D;
	SoundManager.Musicvolume = 1.0f;	
		}
	}
	
	void ChangeSound(){
	if(SoundManager.Soundvolume == 1.0f){
	Soundstyle.normal.background = Resources.Load("X") as Texture2D;
	SoundManager.Soundvolume = 0.0f;
		}
	else{
	Soundstyle.normal.background = Resources.Load("Check") as Texture2D;
	SoundManager.Soundvolume = 1.0f;	
		}
	}
}
