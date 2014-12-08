using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class ResizeUI : MonoBehaviour {
	public float Ratio=600F;
	void Start () {
		Component[] allTexts=GetComponentsInChildren<Text>();
		foreach(Text t in allTexts) ResizeText (t);
	}

	void ResizeText(Text t){
		if(Screen.width<Ratio)
		t.fontSize=(int) (t.fontSize*Screen.width/Ratio);

	}
}
