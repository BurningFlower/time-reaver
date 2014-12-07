using UnityEngine;
using System.Collections;

public class ClocksEvents : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GravityChange(){
		GameObject.FindGameObjectWithTag ("Player").rigidbody2D.gravityScale /= 2;
	}

	void NotMoreBackgroundObjects(){
		BackgroundObjectSpawner.layer = 20;

	}

}
