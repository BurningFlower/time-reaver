using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class ScoreHandler : MonoBehaviour {
	public Text text;
	public float timeScore;
	private float score;
	private bool activeScore;
	// Use this for initialization
	void Start () {
		activeScore=true;
		score=0F;
		text.text="";
	}

	void Update () {
		if(activeScore)	score+=timeScore*Time.deltaTime;
	}
	void OnGUI(){
		text.text=((int)score).ToString();
	}
	public void AddPoints(int points){
		if(activeScore) score+=points;
	}
	public void StopCounter(){
		activeScore=false;
	}
	public void SaveScore(){
		SavedData.SetHighscore((int) (score));
	}
}
