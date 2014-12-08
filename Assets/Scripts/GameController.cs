using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public ScoreHandler scoreHandler;
	public PlatformGenerator platformGenerator;

	public void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) ReturnMainMenu ();

	}
	public void GameOver(){
		scoreHandler.StopCounter();
		scoreHandler.SaveScore();
		platformGenerator.generate=false;
		Invoke("ReturnMainMenu",2F);
	}
	public void ReturnMainMenu(){
		Application.LoadLevel("MainMenu");
	}
}
