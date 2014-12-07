using UnityEngine;
using System.Collections;

public class ClockHand : MonoBehaviour {

	private float time=60f;
	private int rotations=10;
	private float rotationAngle;
	private float rotationTime;
	private float rotation;


	// Use this for initialization
	void Start () {
		rotation = 0f;
		rotationAngle = 360f / rotations;
		rotationTime = time / rotations;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Rotate(){

		rotation = rotation + rotationAngle;
		rigidbody2D.MoveRotation (rotationAngle);
		Invoke ("Rotate", rotationTime);
	}
}
