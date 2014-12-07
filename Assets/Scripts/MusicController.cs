using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class MusicController : MonoBehaviour {
	public AudioClip[] Music;
	private int current;
	private float vol;
	void Start () {
		CheckAudio ();
		audio.loop = false;
		current = Random.Range ((int)0,(int)Music.Length-1);
		audio.playOnAwake = false;
		vol=audio.volume;
		audio.volume=0F;
		PlayNext ();
	}

	void Update () {
		CheckAudio ();
		if (!audio.isPlaying)
						PlayNext ();
		if(audio.volume<vol){
			audio.volume+=0.1F*Time.deltaTime;
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
		if (SavedData.ActiveMusic)
			audio.mute = false;
		else
			audio.mute = true;
	}

}
