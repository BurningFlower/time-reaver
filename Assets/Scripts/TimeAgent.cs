using UnityEngine;
using System.Collections;

public class TimeAgent : MonoBehaviour {
	public float shootDelay;
	public GameObject shoot;
	// Use this for initialization
	void Start () {
		Invoke ("Shoot",shootDelay);
	}
	
	// Update is called once per frame
	void EnemyDie(){
		CancelInvoke();
		Destroy (gameObject);
	}
	void Shoot(){
		Instantiate (shoot,transform.position,Quaternion.identity);
	}
}
