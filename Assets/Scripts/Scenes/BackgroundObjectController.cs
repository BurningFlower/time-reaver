using UnityEngine;
using System.Collections;


public class BackgroundObjectController : MonoBehaviour {
	
	private float strenght;
	public float strenghtLimitA = -3.5f;
	public float strenghtLimitB = 3.5f;
	private float speedRotation;
	private float rotation=0f;
	private float maxLimit, minLimit;
	private bool raising;
	// Use this for initialization
	void Start () {
		rigidbody2D.gameObject.layer = BackgroundObjectSpawner.GetLayer();
		strenght=Random.Range (strenghtLimitA,strenghtLimitB);
		
		if (strenght > 0f)
			raising = true;
		else
			raising = false;
		
		speedRotation=Random.Range (1f,5f);
		rigidbody2D.AddForce (new Vector2(Random.Range (20f, 60f),0f));
		
		maxLimit = rigidbody2D.position[1] + Random.Range (0f, 2f);
		minLimit = (-maxLimit);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if( (rigidbody2D.position[1] > maxLimit) && raising) {
			strenght= (-strenght);
			raising = false;
		}
		
		if( (rigidbody2D.position[1] < minLimit) && !raising) {
			strenght= (-strenght);
			raising = true;
		}
		
		rigidbody2D.AddForce (new Vector2 (0, strenght));
		rotation = (rotation + speedRotation) % 360;
		rigidbody2D.MoveRotation(rotation);
	}
}
