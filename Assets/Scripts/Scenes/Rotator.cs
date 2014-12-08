using UnityEngine;
using System.Collections;

	public class Rotator : MonoBehaviour {
		public float rotationSpeed;
		
		void FixedUpdate () {
			transform.Rotate (Vector3.right*rotationSpeed*Time.deltaTime);
		}
	}
