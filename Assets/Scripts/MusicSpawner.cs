using UnityEngine;
using System.Collections;

public class MusicSpawner : MonoBehaviour {
	public GameObject musicObject;
	// Use this for initialization
	void Start () {
		if(GameObject.Find("Music(Clone)") == null) {
			Instantiate (musicObject);    
		}
	}

}
