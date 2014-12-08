using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/


public class BoundaryHandler : MonoBehaviour {
	public GameController gameController;
	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.tag=="Player") gameController.GameOver();
		Destroy(col.gameObject);
	}
}
