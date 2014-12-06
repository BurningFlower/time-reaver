using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class PlatformController : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		speed=Mathf.Abs (speed);
		rigidbody2D.velocity=new Vector2(-speed,0);
		rigidbody2D.drag=0F;
	}

	void FixedUpdate () {
	
	}
}
