using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class HighScoreMM : MonoBehaviour {
	public Text text;

	void Start () {
		text.text="High Score:"+SavedData.highScore;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
