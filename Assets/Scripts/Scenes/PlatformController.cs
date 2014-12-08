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
	}

	void FixedUpdate () {
		transform.Translate(Vector3.left*Time.deltaTime*speed);
	
	}
}
