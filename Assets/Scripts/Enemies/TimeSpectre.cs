using UnityEngine;
using System.Collections;

public class TimeSpectre : MonoBehaviour {
	public int points;
	public float speed=10F;
	
	private Vector3 direction;
	void Start () {
		Transform playerPos = GameObject.FindGameObjectWithTag ("Player").transform;
		direction=playerPos.position-transform.position;
		direction=direction/direction.magnitude;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction*Time.deltaTime*speed);
	}
	void EnemyDie(){
		GameObject gc=GameObject.FindWithTag("GameController");
		gc.GetComponent<ScoreHandler>().AddPoints(points);
		Destroy (gameObject);
	}
}
