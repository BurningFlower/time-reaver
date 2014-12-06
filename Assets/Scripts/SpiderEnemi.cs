using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public float limitInfA=1f;
	public float limitSupA=3f;

	public float A;
	private float y=0f;
	private float x=0;
	
	//y = amplitud * sin((x*valor+grado_inicio)%360)+inicio;
	// Use this for initialization
	void Start () {
		
		A = Random.Range (limitInfA, limitSupA);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		y = A * Mathf.Sin ((20 + x)%360);
		rigidbody2D.MovePosition (new Vector2 (0, y));
		x = x + 0.1f;
		
		
	}
}