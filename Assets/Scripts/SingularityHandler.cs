using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/

public class SingularityHandler : MonoBehaviour {
	public float MinTime=6F;
	public float MaxTime=12F;
	public string[] singularities;
	void Start () {
		Invoke ("StartSingularity",Random.Range (MinTime,MaxTime));
	}
	
	void StartSingularity(){
		Invoke (singularities [Random.Range((int)0,(int) singularities.Length-1)],0);
		Invoke ("StartSingularity",Random.Range (MinTime,MaxTime));
	}
}
