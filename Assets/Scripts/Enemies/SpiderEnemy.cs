using UnityEngine;
using System.Collections;

public class SpiderEnemy : MonoBehaviour {
	public int points;
	public float limitInfA=1f;
	public float limitSupA=3f;
	public float velx=100;

	public float Amplitude;

	private float y;
	private float x;
	private float posx;
	
	//y = amplitud * sin((x*valor+grado_inicio)%360)+inicio;
	// Use this for initialization
	void Start () {
		//rigidbody2D.velocity=(new Vector2 (-velx,0));
		Amplitude = Random.Range (limitInfA, limitSupA);
		y = rigidbody2D.transform.position.y;
		x = 0;
		posx = rigidbody2D.transform.position.x;
		Invoke ("PosX", 0.1f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		y = Amplitude * Mathf.Sin ((20 + x)%360);
		rigidbody2D.MovePosition (new Vector2 (posx, y));
		x = x + 0.1f;
		
		
	}

	void PosX(){
		posx = posx - (velx*0.01f);
		Invoke ("PosX", 0.01f);
	}


	void EnemyDie(){
		audio.Play ();
		GameObject gc=GameObject.FindWithTag("GameController");
		gc.GetComponent<ScoreHandler>().AddPoints(points);
		Destroy (gameObject);
	}
}