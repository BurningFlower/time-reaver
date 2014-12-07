﻿using UnityEngine;
using System.Collections;

public class TimeSpectre : MonoBehaviour {

	private int spectreStage;
	private const int stages = 5;
	private bool preparedChange;
	public float force =3f;  
	public float distanceStage0=4f;
	public float distanceStage3=4f;
	public GameObject player;

	// Use this for initialization
	void Start () {
		spectreStage = 0;
		rigidbody2D.MovePosition ( new Vector2((player.transform.position.x + distanceStage0), player.transform.position.y));

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		switch(spectreStage){
		case 0:
			rigidbody2D.MovePosition ( new Vector2(player.transform.position.x + distanceStage0,
			                                       player.transform.position.y));
			break;
		case 1:
			rigidbody2D.AddForce ( new Vector2 (force,0));
			break;
		case 2:
			rigidbody2D.AddForce (new Vector2 (-force , 0));
			break;
		case 3:
			rigidbody2D.MovePosition ( new Vector2(player.transform.position.x + distanceStage3, player.transform.position.y));
			rigidbody2D.velocity=(new Vector2 (0,0));
			break;
		case 4:
			rigidbody2D.AddForce ( new Vector2 (-force,0));
			break;

		}


	
	}

	void Update () {

		if (spectreStage == 0 && !preparedChange) {
			preparedChange = !preparedChange;
			Invoke("ChangeOfStage",3f);
		}

		if (spectreStage == 1 && (rigidbody2D.transform.position.x < player.transform.position.x)) {

			preparedChange = !preparedChange;
			ChangeOfStage ();

		}

		if (spectreStage == 2 && ((rigidbody2D.transform.position.x - player.transform.position.x) > distanceStage3)) {
			preparedChange = !preparedChange;
			ChangeOfStage ();
		
		}

	
		if (spectreStage == 3 && !preparedChange) {
			preparedChange = !preparedChange;
			Invoke("ChangeOfStage",1.5f);
		}

		if (spectreStage == 4 && ((rigidbody2D.transform.position.x - player.transform.position.x) > distanceStage0)) {
			
			preparedChange = !preparedChange;
			ChangeOfStage ();
			
		}
	
	
	}

	private void ChangeOfStage(){
		spectreStage = (spectreStage + 1) % stages;
		preparedChange = !preparedChange;

	}
}
