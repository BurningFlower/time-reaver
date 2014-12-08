using UnityEngine;
using System.Collections;

public class SpiderSpawn : MonoBehaviour {

	public GameObject  obj;
	public float timeSpawn1=2f;
	public float timeSpawn2=3f;
	public float spawnPositionY1=-0.3f;
	public float spawnPositionY2=0.3f;
	// Use this for initialization
	void Start () {
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn(){
		
		GameObject t=Instantiate (obj , new Vector2(transform.position.x,transform.position.y+Random.Range (spawnPositionY1, spawnPositionY2)), Quaternion.identity) as GameObject;
		t.transform.parent=transform;
		Invoke ("Spawn", Random.Range (timeSpawn1, timeSpawn2));
	}
}
