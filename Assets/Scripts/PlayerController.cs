using UnityEngine;
using System.Collections;

/** PROJECT: Time-Reaper **/
/** AUTHOR: DEMIURGOS **/
/** VERSION: 0.1 **/


public class PlayerController : MonoBehaviour {
    public float speed=1F;
    public float jumpForce=1F;
    public int buttonOffset=20; //spcae beetween buttons (in pixels)
    public float attackWaitTime=2F;

    private bool attacking;


    private enum ControllerType {Mobile,Computer};
    private ControllerType controllerSelection; //kind of controller

    private Animator anim; //animator

    private float attackTimer;
    private int b1,b2; //position of buttons
    private bool grounded; //true if touching floor
    private bool jmp; //true when jumping
    private bool attacked; //true if attacked (in air)

    private bool jumpButton; //true while pushed
    private bool attackButton;  //true when pushed (false after frame)
    void Awake() {
		anim=gameObject.GetComponent<Animator>();
        attacking=false;
		attacked=false;
        grounded=false;
        jmp=false;
        jumpButton=false;
        attackButton=false;
        speed=Mathf.Abs(speed);
        jumpForce=Mathf.Abs (jumpForce);
        buttonOffset=Mathf.Abs (buttonOffset);
        attackWaitTime=Mathf.Abs (attackWaitTime);
        controllerSelection=ControllerType.Computer;
        attackTimer=0;
        b1=0;
        b2=0;
    }
    void Start () {
        b1=(Screen.width-buttonOffset)/2;
        b2=(Screen.width+buttonOffset)/2;
        controllerSelection=SelectController(); //selects controller from platform
    }
    void Update () {
        if(controllerSelection==ControllerType.Mobile) MobileController();
        else ComputerController();
    }
    void FixedUpdate() {
		if(jumpButton) Jump ();
		if(attackButton) Attack ();

    }
    void OnCollisionEnter2D(Collision2D collider) {
        if(collider.gameObject.tag=="Floor") {
            grounded=true;
            attacked=false;
            jmp=false;
            anim.SetTrigger (Animator.StringToHash ("Run"));
        }
    }
    void OnCollisionExit2D(Collision2D collider) {
        if(collider.gameObject.tag=="Floor") {
            grounded=false;
            jmp=false;
            if(!jmp) anim.SetTrigger (Animator.StringToHash ("Fall"));
        }
		else if(collider.gameObject.tag=="Enemy"){
			if(!attacking) PlayerDies();
			else collider.gameObject.SendMessage("EnemyDie");

		}
		else if(collider.gameObject.tag=="Spikes"){
			PlayerDies();
		}
    }
    void OnCollsionStay2D(Collision2D coll) {
        if(collider.gameObject.tag=="Floor") { //this shouldn't be necessary
            grounded=true;
            attacked=false;
        }
    }
    //CONTROLLERS
    //makes lbutton and rbutton true when necessary
    void MobileController() {
        foreach(Touch touch in Input.touches) {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
                if(touch.position.x<b1) jumpButton=true;
                else if(touch.phase==TouchPhase.Began && touch.position.x>b2) attackButton=true;
            }
        }
    }
    void ComputerController() {
        if(Input.GetButton ("Jump")) jumpButton=true;
        if(Input.GetButtonDown ("Fire1")) attackButton=true;
    }

    //PLAYER ACTIONS
    //jump with given force (if grounded==true)
    void Jump() {
        if(grounded) {
            rigidbody2D.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
            anim.SetTrigger (Animator.StringToHash ("Jump"));
            jmp=true;
            //grounded=false; //Maybe neccessary?
        }
    }
    void Attack() {
        if(!attacked && Time.time>attackTimer) {
            attacked=true;
            attacking=true;
            anim.SetTrigger (Animator.StringToHash ("Attack"));
            attackTimer=Time.time+attackWaitTime;
            attackButton=false;


        }
    }
    void AttackEnd() {
        attacking=false;
        if(!grounded) anim.SetTrigger (Animator.StringToHash ("Fall"));
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



	}
}
