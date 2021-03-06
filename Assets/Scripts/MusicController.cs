using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class MusicController : MonoBehaviour {
	public AudioClip[] Music;
	public float FadeInSpeed=0.1F;
	private int current;
	private float vol;
	void Start () {
		if(GameObject.Find("Music") != null) {
			Destroy (gameObject);    
		}
		CheckAudio ();
		audio.loop = false;
		current = Random.Range ((int)0,(int)Music.Length-1);
		audio.playOnAwake = false;
		vol=audio.volume;
		audio.volume=0F;
		PlayNext ();
		DontDestroyOnLoad(gameObject);
	}

	void Update () {
		CheckAudio ();
		if (!audio.isPlaying)
						PlayNext ();
		if(audio.volume<vol){
			audio.volume+=FadeInSpeed*Time.deltaTime;
		}
	}

	void PlayNext(){
		NextSong ();
		audio.Play ();
	}
	void NextSong(){
		current++;
		current%=Music.Length;
		audio.clip = Music [current];
		}
	void CheckAudio(){
		if (SavedData.activeMusic)
			audio.mute = false;
		else
			audio.mute = true;
	}

}
