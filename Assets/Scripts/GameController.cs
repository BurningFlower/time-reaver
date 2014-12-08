using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
	public ScoreHandler scoreHandler;
	public PlatformGenerator platformGenerator;
	public GameObject enemySpawner;
	private EnemySpawn[] enemySpawns;
	public Text gameOver;
	public float fadeTime;
	public Color color1;
	public Color color2;

	private bool fadeText;
	private float tFade;

	
	public void Start(){
		enemySpawns=enemySpawner.GetComponents<EnemySpawn>();
		gameOver.color=color1;
	}

	public void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) ReturnMainMenu ();
		if(fadeText) gameOver.color=Color.Lerp (color1,color2,(Time.time-tFade)/fadeTime);

	}
	public void GameOver(){
		scoreHandler.StopCounter();
		scoreHandler.SaveScore();
		platformGenerator.generate=false;
		foreach(EnemySpawn es in enemySpawns) es.generate=false;
		audio.Play ();
		tFade=Time.time;
		fadeText=true;
		Invoke("ReturnMainMenu",5F);
	}
	public void ReturnMainMenu(){
		Application.LoadLevel("MainMenu");
	}
}
