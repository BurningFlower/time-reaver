using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public ScoreHandler scoreHandler;
	public PlatformGenerator platformGenerator;


	public void GameOver(){
		scoreHandler.StopCounter();
		scoreHandler.SaveScore();
		platformGenerator.generate=false;
	}
}
