using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class MusicController : MonoBehaviour {
	public AudioClip[] Music;
	private int current;

	void Start () {
		CheckAudio ();
		audio.loop = false;
		current = Random.Range ((int)0,(int)Music.Length);
		audio.playOnAwake = false;
		audio.Play ();
	}

	void Update () {
		CheckAudio ();
		if (!audio.isPlaying)
						PlayNext ();
	}

	void PlayNext(){
		NextSong ();
		audio.Play ();
	}
	void NextSong(){
		current++;
		current%=Music.Length;
		}
	void CheckAudio(){
		if (SavedData.ActiveMusic)
			audio.mute = false;
		else
			audio.mute = true;
	}

}
