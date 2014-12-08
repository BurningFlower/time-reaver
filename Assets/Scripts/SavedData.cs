using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public static class SavedData{
	public static bool activeMusic;
	public static bool activeSound;
	public static int highScore;

	static SavedData(){
			activeMusic =ToBool (PlayerPrefs.GetInt ("ActiveMusic", 1));
			activeSound =ToBool(PlayerPrefs.GetInt ("ActiveSound",1));
			highScore=PlayerPrefs.GetInt ("HighScore",0);
	}
	public static void SaveOptions(){
		PlayerPrefs.SetInt ("ActiveMusic",ToInt(activeMusic));
		PlayerPrefs.SetInt ("ActiveSound",ToInt(activeSound));
	}
	public static void SetHighscore(int Score){
		if (highScore < Score) {
			highScore=Score;
			PlayerPrefs.SetInt ("HighScore",highScore);
				}

		}
	private static int ToInt(bool b){
		return b ? 1 : 0;
	}
	private static bool ToBool(int i){
		return (i != 0);
	}
}