using UnityEngine;
using System.Collections;

public class BackgroundObjectSpawner : MonoBehaviour {

	public GameObject [] obj;
	public float timeSpawn1=2f;
	public float timeSpawn2=3f;
	private static int layer;

	// Use this for initialization
	void Start () {
		layer = -5;
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn(){

		Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
		Invoke ("Spawn", Random.Range (timeSpawn1, timeSpawn2));
	}

	public static void SetLayer(int layerValue){
		layerValue=layerValue;
	}

}
