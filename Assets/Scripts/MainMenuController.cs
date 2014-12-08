using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class MainMenuController : MonoBehaviour {
	public GameObject optionsMenu;
	
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) ExitGame ();

	}
	public void StartGame(){
		Application.LoadLevel("Main");
	}
	public void ExitGame(){
	Application.Quit();
	}
	public void OptionsMenu(){
		optionsMenu.SetActive (true);
		gameObject.SetActive (false);
	}
}
