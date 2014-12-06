using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class SceneryGenerator : MonoBehaviour {
	public GameObject platform;
	public GameObject[] spikePlatform; //all the platforms with spikes
	public int spikerPercentage=50;
	public Vector2 minSize=new Vector2(0.5F,0.3F);
	public Vector2 maxSize=new Vector2(2F,0.6F);

	public Vector2 minSpawnDistance;
	public Vector2 maxSpawnDistance;

	private Transform lastSpawn; //last object spawned
	private Vector2 nextObjectDistance;
	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs (lastSpawn.position.x-transform.position.x)>=nextObjectDistance.x){
			Spawn();
		}
	}

	//instantiates new object and refresh lastSpawn and nextObjectDistance
	void Spawn(){
		if(Random.value<spikerPercentage/100){ //chance of setting a spike
				lastSpawn=Instantiate (spikePlatform[Random.Range ((int)0,(int)spikePlatform.Length-1)],transform.position,Quaternion.identity) as Transform;		
		}

		else{ //platform without spikes
			lastSpawn=Instantiate (platform,transform.position,Quaternion.identity) as Transform;
			Vector2 size= new Vector2(Random.Range (minSize.x,maxSize.x),Random.Range (minSize.y,maxSize.y));
			lastSpawn.localScale=new Vector3(size.x,size.y,lastSpawn.localScale.z);
		}

	}
}
