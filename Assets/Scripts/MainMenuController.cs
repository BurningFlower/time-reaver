using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class MainMenuController : MonoBehaviour {
	public GameObject optionsMenu;
	public GameObject soundController;
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) ExitGame ();

	}
	public void StartGame(){
		soundController.audio.Play();
		Application.LoadLevel("Main");
	}
	public void ExitGame(){
		soundController.audio.Play();
		Application.Quit();
	}
	public void OptionsMenu(){
		soundController.audio.Play();
		optionsMenu.SetActive (true);
		gameObject.SetActive (false);
	}
}
