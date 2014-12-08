using UnityEngine;
using System.Collections;

public class SpiderSpaw : MonoBehaviour {

	public GameObject  obj;
	public float timeSpawn1=2f;
	public float timeSpawn2=3f;
	// Use this for initialization
	void Start () {
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn(){
		
		Instantiate (obj , new Vector2( transform.position.x,transform.position.y), Quaternion.identity);
		Invoke ("Spawn", Random.Range (timeSpawn1, timeSpawn2));
	}
}
