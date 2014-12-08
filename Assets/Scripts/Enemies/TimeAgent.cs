using UnityEngine;
using System.Collections;

public class TimeAgent : MonoBehaviour {
	public int points;
	//public GameObject shoot;
	// Use this for initialization
	void Start () {
	//	Invoke ("Shoot",shootDelay);
	}
	
	// Update is called once per frame
	void EnemyDie(){
		GameObject gc=GameObject.FindWithTag("GameController");
		gc.GetComponent<ScoreHandler>().AddPoints(points);
		Destroy (gameObject);
	}
/*	void Shoot(){
		Instantiate (shoot,transform.position,Quaternion.identity);
	}*/
}
