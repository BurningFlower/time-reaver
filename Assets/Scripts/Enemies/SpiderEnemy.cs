using UnityEngine;
using System.Collections;

public class SpiderEnemy : MonoBehaviour {

	public float limitInfA=1f;
	public float limitSupA=3f;

	public float A;
	private float y;
	private float x=0;
	
	//y = amplitud * sin((x*valor+grado_inicio)%360)+inicio;
	// Use this for initialization
	void Start () {
		
		A = Random.Range (limitInfA, limitSupA);
		y = rigidbody2D.transform.position.y;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		y = A * Mathf.Sin ((20 + x)%360);
		rigidbody2D.MovePosition (new Vector2 (0, y));
		x = x + 0.1f;
		
		
	}
}