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
	public Vector2 minSize=new Vector2(6F,1F);
	public Vector2 maxSize=new Vector2(8F,1F);
	
	public Vector2 minSpawnRange=new Vector2(7F,1F);
	public Vector2 maxSpawnRange=new Vector2(9F,3.5F);

	public float rangeY=6F;
	public GameObject firstPlatform;
	private GameObject lastSpawn; //last object spawned
	private Vector2 nextObjectDistance;
	// Use this for initialization
	void Start () {
		lastSpawn=firstPlatform;
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
		Vector2 pos=lastSpawn.transform.position;
		pos.y+=nextObjectDistance.y;
		pos.x=transform.position.x;
		
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
		}
		lastSpawn.transform.parent=transform;
		GetNewDistance();
	}
	void GetNewDistance(){
		float x=Random.Range (minSpawnRange.x,maxSpawnRange.x);
		float y=Random.Range (minSpawnRange.y,maxSpawnRange.y);
		if(Random.value<0.5) y=-y;
		y=Mathf.Clamp (y,transform.position.y-rangeY,transform.position.y+rangeY);
		nextObjectDistance=new Vector2(x,y);
	}
}
