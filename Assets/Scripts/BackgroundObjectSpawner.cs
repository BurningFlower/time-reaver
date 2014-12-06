using UnityEngine;
using System.Collections;

public class BackgroundObjectSpawner : MonoBehaviour {

	public GameObject [] obj;
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

		Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
		Invoke ("Spawn", Random.Range (timeSpawn1, timeSpawn2));
	}

}
