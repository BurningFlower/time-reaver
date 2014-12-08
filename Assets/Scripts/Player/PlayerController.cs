using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/


public class PlayerController : MonoBehaviour {
    public float jumpForce=1F;
    public int buttonOffset=20; //spcae beetween buttons (in pixels)
    public float attackWaitTime=2F;
	public ParticleEmitter attackParticles;
	public GameObject mainCamera;

    private enum ControllerType {Mobile,Computer};
    private ControllerType controllerSelection; //kind of controller

    private Animator anim; //animator

	private bool attacking;
    private float attackTimer;
    private int b1,b2; //position of buttons
    private bool grounded; //true if touching floor
    private bool jmp; //true when jumping
    private bool attacked; //true if attacked (in air)

    private bool jumpButton; //true while pushed
    private bool attackButton;  //true when pushed (false after frame)

//	private CameraController camCont;
    void Awake() {
		anim=gameObject.GetComponentInChildren<Animator>();
        attacking=false;
		attacked=false;
        jmp=false;
        jumpButton=false;
        attackButton=false;
        jumpForce=Mathf.Abs (jumpForce);
        buttonOffset=Mathf.Abs (buttonOffset);
        attackWaitTime=Mathf.Abs (attackWaitTime);
        controllerSelection=ControllerType.Computer;
        attackTimer=0;
        b1=0;
        b2=0;
    }
    void Start () {
		SetGrounded(false);
        b1=(Screen.width-buttonOffset)/2;
        b2=(Screen.width+buttonOffset)/2;
        controllerSelection=SelectController(); //selects controller from platform
		//camCont=mainCamera.GetComponent<CameraController>();
    }
    void Update () {
        if(controllerSelection==ControllerType.Mobile) MobileController();
        else ComputerController();

    }
    void FixedUpdate() {
		if(jumpButton) Jump ();
		if(attackButton) Attack ();

		if(attacking) rigidbody2D.velocity=new Vector2(0,0);

    }
    void OnCollisionEnter2D(Collision2D collider) {
        if(collider.gameObject.tag=="Floor") {
			SetGrounded (true);
            attacked=false;
            jmp=false;
  //          anim.SetTrigger (Animator.StringToHash ("TouchGround"));
			//camCont.SetNormalCamera();
        }
		else if(collider.gameObject.tag=="Enemy"){
			if(!attacking) PlayerDies();
			else collider.gameObject.SendMessage("EnemyDie");
			
		}
		else if(collider.gameObject.tag=="Spikes"){
			PlayerDies();
		}
    }
    void OnCollisionExit2D(Collision2D collider) {
        if(collider.gameObject.tag=="Floor") {
			SetGrounded (false);
	//		anim.ResetTrigger (Animator.StringToHash ("TouchGround"));
            if(!jmp) anim.SetTrigger (Animator.StringToHash ("Falling"));
        }

    }
    void OnCollisionStay2D(Collision2D collider) {
        if(collider.gameObject.tag=="Floor") {
			SetGrounded (true);
            attacked=false;
        }
    }
    //CONTROLLERS
    //makes lbutton and rbutton true when necessary
    void MobileController() {
		jumpButton=false;
		//attackButton=false;
        foreach(Touch touch in Input.touches) {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
                if(touch.position.x<b1) jumpButton=true;
                else if(touch.phase==TouchPhase.Began && touch.position.x>b2) attackButton=true;
            }
        }
    }
    void ComputerController() {
		jumpButton=false;
		//attackButton=false;
        if(Input.GetButton ("Jump")) jumpButton=true;
        if(Input.GetButtonDown ("Fire1")) attackButton=true;
    }

    //PLAYER ACTIONS
    //jump with given force (if grounded==true)
   void Jump() {
        if(grounded && !jmp) {
			jmp=true;
            anim.SetTrigger (Animator.StringToHash ("Jump"));
			rigidbody2D.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			SetGrounded (false);
        }
    }
    void Attack() {
		attackButton=false;
        if(!attacked && Time.time>attackTimer && !attacking) {
			attackParticles.emit=true;
			audio.Play();
            attacked=true;
            attacking=true;
            anim.SetTrigger (Animator.StringToHash ("Attack"));
            attackTimer=Time.time+attackWaitTime;
			Invoke ("FinishAttack",0.7F);
        }
    }
    void AttackEnd() {
        attacking=false;
        if(!grounded) anim.SetTrigger (Animator.StringToHash ("Falling"));
        else anim.SetTrigger (Animator.StringToHash ("Run"));
    }

    //OTHER METHODS
    ControllerType SelectController() {
        ControllerType selection;
        switch(Application.platform) { //selects platform for control
        case RuntimePlatform.WindowsPlayer:
            selection=ControllerType.Computer;
            break;
        case RuntimePlatform.OSXPlayer:
            selection=ControllerType.Computer;
            break;
        case RuntimePlatform.LinuxPlayer:
            selection=ControllerType.Computer;
            break;
        case RuntimePlatform.WindowsWebPlayer:
            selection=ControllerType.Computer;
            break;
        case RuntimePlatform.OSXWebPlayer:
            selection=ControllerType.Computer;
            break;
        case RuntimePlatform.Android:
            selection=ControllerType.Mobile;
            break;
        case RuntimePlatform.IPhonePlayer:
            selection=ControllerType.Mobile;
            break;
        default:
            selection=ControllerType.Computer; //if not listed, computer is used
            break;
        }
        return selection;
    }
	void PlayerDies(){
		Debug.Log ("GameOver");


	}
	void SetGrounded(bool g){
		grounded=g;
		anim.SetBool ("Grounded",g);
	}
	void FinishAttack(){
		attackParticles.emit=false;
		attacking=false;
	}
}
