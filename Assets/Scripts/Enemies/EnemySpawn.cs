using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	public bool generate=true;
	public GameObject  obj;
	public float timeSpawn1=2f;
	public float timeSpawn2=3f;
	public float spawnPositionY1=-0.3f;
	public float spawnPositionY2=0.3f;
	// Use this for initialization
	void Start () {
		Invoke ("Spawn", Random.Range (timeSpawn1, timeSpawn2));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn(){
		if(generate){
		GameObject t=Instantiate (obj , new Vector3(transform.position.x,transform.position.y+Random.Range (spawnPositionY1, spawnPositionY2),transform.position.z), Quaternion.identity) as GameObject;
		t.transform.parent=transform;
		}
		Invoke ("Spawn", Random.Range (timeSpawn1, timeSpawn2));
	}
}
