using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class OptionsMenuController : MonoBehaviour {
	public Toggle music;
	public Toggle sound;
	public GameObject mainMenu;
	
	void Start(){
		music.isOn=SavedData.activeMusic;
		sound.isOn=SavedData.activeSound;
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) Return ();
		
	}
	public void SetMusic(){
		SavedData.activeMusic=music.isOn;
	}
	public void SetSounds(){
		SavedData.activeSound=sound.isOn;
	}
	public void Return(){
		SavedData.SaveOptions();
		mainMenu.SetActive (true);
		gameObject.SetActive (false);
		
	}
}
