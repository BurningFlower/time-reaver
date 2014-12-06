using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/


public class BoundaryHandler : MonoBehaviour {
	
	void OnTriggerExit2D(Collider2D col) {
		Destroy(col.gameObject);
	}
}
