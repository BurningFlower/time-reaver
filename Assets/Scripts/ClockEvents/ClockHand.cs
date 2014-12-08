using UnityEngine;
using System.Collections;

public class ClockHand : MonoBehaviour {

	public float time=60f;
	private int rotations=60;
	private float rotationAngle;
	private float rotationTime;
	private float rotation;


	// Use this for initialization
	void Start () {
		rotation = 0f;
		rotationAngle = 360f / rotations;
		rotationTime = time / rotations;
		Invoke ("Rotate", rotationTime);
		Invoke ("Event",time);
	}
	

	void Rotate(){
		rotation = (rotation + rotationAngle)%360;
		rigidbody2D.MoveRotation (rotation);
		Invoke ("Rotate", rotationTime);
	}
	void Event(){
		audio.Play ();
		//events.NewEvent();
	}
}
