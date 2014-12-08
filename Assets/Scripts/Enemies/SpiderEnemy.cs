﻿using UnityEngine;
using System.Collections;

public class SpiderEnemy : MonoBehaviour {

	public ScoreHandler scoreHandler;
	public int points;
	public float limitInfA=1f;
	public float limitSupA=3f;
	public float velx=10;

	public float A;
	private float y;
	private float x=0;
	
	//y = amplitud * sin((x*valor+grado_inicio)%360)+inicio;
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity=(new Vector2 (velx,0));
		A = Random.Range (limitInfA, limitSupA);
		y = rigidbody2D.transform.position.y;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		y = A * Mathf.Sin ((20 + x)%360);
		rigidbody2D.MovePosition (new Vector2 (0, y));
		x = x + 0.1f;
		
		
	}

	void EnemyDie(){
		Destroy (gameObject);
	}
}