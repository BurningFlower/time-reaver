using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform player;
	public float minSize=6F;
	public float jumpSize=10F;
	public float changeSizeTime=2F;
	public float minPosition=-10F;

	private Camera mainCamera;
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
		float pos=player.position.y;
		if(pos<minPosition) pos=minPosition;
		transform.position = new Vector3 (transform.position.x, pos, -10);
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
