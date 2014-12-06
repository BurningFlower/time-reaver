using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public static class SavedData{
	public static bool ActiveMusic;
	public static bool ActiveSound;
	public static int HighScore;

	static SavedData(){
			ActiveMusic =ToBool (PlayerPrefs.GetInt ("ActiveMusic", 1));
			ActiveSound =ToBool(PlayerPrefs.GetInt ("ActiveSound",1));
			HighScore=PlayerPrefs.GetInt ("HighScore",0);
	}
	public static void SaveOptions(){
		PlayerPrefs.SetInt ("ActiveMusic",ToInt(ActiveMusic));
		PlayerPrefs.SetInt ("ActiveSound",ToInt(ActiveSound));
	}
	public static void SetHighscore(int Score){
		if (HighScore < Score) {
			HighScore=Score;
			PlayerPrefs.SetInt ("HighScore",HighScore);
				}

		}
	private static int ToInt(bool b){
		return b ? 1 : 0;
	}
	private static bool ToBool(int i){
		return (i != 0);
	}
}