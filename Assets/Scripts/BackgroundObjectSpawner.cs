using UnityEngine;
using System.Collections;

public class BackgroundObjectSpawner : MonoBehaviour {

	public GameObject [] obj;

	// Use this for initialization
	void Start () {
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn(){

		Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
		Invoke ("Spawn", Random.Range (2f, 3f));
	}

}
