using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class MuteSound : MonoBehaviour {
	void Update(){
		if (SavedData.activeSound)
			audio.mute = false;
		else
			audio.mute = true;
	}
}
