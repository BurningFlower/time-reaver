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
		Component[] allButtons=GetComponentsInChildren<Button>();
		foreach(Button b in allButtons) ResizeButton(b);
	}

	void ResizeText(Text t){
		t.fontSize=(int) (t.fontSize*Screen.width/Ratio);

	}
	void ResizeButton(Button b){
		Vector3 trans=b.transform.localScale;
		trans.x*=Screen.width/Ratio;
		trans.y*=Screen.width/Ratio;
		b.transform.localScale=trans;
	}
}
