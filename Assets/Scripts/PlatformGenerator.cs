using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class PlatformGenerator : MonoBehaviour {
	public GameObject platform;
	public GameObject[] spikePlatform; //all the platforms with spikes
	public GameObject enemyPlatform;
	public float spikerPercentage=40;
	public float enemyPercentage=20;
	public Vector2 minSize=new Vector2(0.5F,0.3F);
	public Vector2 maxSize=new Vector2(2F,0.6F);
	
	public Vector2 minSpawnRange=new Vector2(0.5F,-4F);
	public Vector2 maxSpawnRange=new Vector2(2F,4F);
	public float minJumpSpace=0.5F;
	
	private GameObject lastSpawn; //last object spawned
	private Vector2 nextObjectDistance;
	// Use this for initialization
	void Start () {
		GetNewDistance ();
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		if (!lastSpawn)
			Spawn ();
		else if(Mathf.Abs (lastSpawn.transform.position.x-transform.position.x)>=nextObjectDistance.x){
			Spawn();
		}
	}
	
	//instantiates new object and refresh lastSpawn and nextObjectDistance
	void Spawn(){
		float rand=Random.value*100;
		Vector2 pos=transform.position;
		pos.y+=nextObjectDistance.y;
		//if(Mathf.Abs(nextObjectDistance.y)>minJumpSpace)	pos.y+=nextObjectDistance.y;
		
		if(rand<enemyPercentage){
			lastSpawn=Instantiate (enemyPlatform,pos,Quaternion.identity) as GameObject;	
		}
		else if(rand<spikerPercentage+enemyPercentage){ //chance of setting a spike
			lastSpawn=Instantiate (spikePlatform[Random.Range ((int)0,(int)spikePlatform.Length-1)],pos,Quaternion.identity) as GameObject;		
		}
		
		else{ //platform without spikes
			lastSpawn=Instantiate (platform,pos,Quaternion.identity) as GameObject;
			Vector2 size= new Vector2(Random.Range (minSize.x,maxSize.x),Random.Range (minSize.y,maxSize.y));
			lastSpawn.transform.localScale=new Vector3(size.x,size.y,lastSpawn.transform.localScale.z);
			GetNewDistance();
		}
		lastSpawn.transform.parent=transform;
	}
	void GetNewDistance(){
		nextObjectDistance=new Vector2(Random.Range (minSpawnRange.x,maxSpawnRange.x),Random.Range (minSpawnRange.y,maxSpawnRange.y));
	}
}
