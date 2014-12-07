using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform player;
	public float minSize;
	public float jumpSize;
	public float changeSizeTime;
	public float cameraSpeed;

	private Camera mainCamera;
	private float moveTime;
	private float sizeTime;
	
	private bool bigSize;

	// Use this for initialization
	void Awake () {
		bigSize = false;
	}
	void Start(){
		mainCamera = gameObject.GetComponent<Camera>();
		}
	// Update is called once per frame
	void Update () {
		if (bigSize) {
			if(mainCamera.orthographicSize!=jumpSize) LerpToJumpSize();
				}
		else if(mainCamera.orthographicSize!=minSize) LerpToSmallSize ();
		RefreshPosition ();

	}

	void LerpToJumpSize(){
		mainCamera.orthographicSize=Mathf.Lerp (jumpSize,minSize,(sizeTime - Time.time) / changeSizeTime);
	}
	void LerpToSmallSize(){
		mainCamera.orthographicSize=Mathf.Lerp (minSize,jumpSize,(sizeTime - Time.time) / changeSizeTime);
		}
	void RefreshPosition(){
		transform.position = new Vector3 (transform.position.x, player.position.y, -10);
	}
	public void SetJumpCamera(){
		bigSize = true;
		sizeTime = Time.time + changeSizeTime;
	}
	public void SetNormalCamera(){
		bigSize = false;
		sizeTime = Time.time + changeSizeTime;
	}

}
