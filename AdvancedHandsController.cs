using UnityEngine;
using System.Collections;

public class AdvancedHandsController : MonoBehaviour {
	
	//Player Vars
	private GameObject player;
	private  CharacterController controller;
	public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
	public float rotateSpeed= -50.0f;
    private Vector3 moveDirection = Vector3.zero;
	//Hand Controllers Vars
	
	//Right
	private GameObject HandRight;
	private HandTriggers TriggersRight;
	//protected Animator r_animator = null;
	public bool RELOADING_RIGHT=false;
	private SixenseInput.Controller HRC;
	//Left
	private GameObject HandLeft;
	private HandTriggers TriggersLeft;
	//protected Animator l_animator = null;
	public bool RELOADING_LEFT=false;
	private SixenseInput.Controller HLC;
	
	
	
	// initialization
	void Start () {		
		
		player= GameObject.Find("OVRPlayerController");
		controller = player.GetComponent<CharacterController>();
		
				
		HandRight = GameObject.Find("Right GunHand");		
	//	r_animator= HandRight.GetComponent<Animator>();
		TriggersRight= HandRight.GetComponent<HandTriggers>();
		
		HandLeft = GameObject.Find("Left GunHand");		
	//	l_animator= HandLeft.GetComponent<Animator>();
		TriggersLeft= HandLeft.GetComponent<HandTriggers>();
		
		HLC= SixenseInput.Controllers[0];
		HRC= SixenseInput.Controllers[1];
	}
	

	void Update () {
		//Get the Input Controllers for each hand
		HLC= SixenseInput.Controllers[0];
		HRC= SixenseInput.Controllers[1];
		
		//***********************************************************************//	
		//************************ MOVING THE PLAYER ****************************//	
		float movX= HLC.JoystickX;
		float rotY= HRC.JoystickX;
		float movY= HLC.JoystickY;
		Debug.Log("Mov: "+movX);
		
		if (controller.isGrounded) {
            moveDirection = new Vector3(movX, 0, movY);
            moveDirection = player.transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
		player.transform.Rotate(0,rotateSpeed*rotY,0);
		//***********************************************************************//	
		//************************** ROTATING OBJECTS ******************************//	
		//Left
		/*
		if(HLC.GetButtonDown(SixenseButtons.BUMPER)){
			
			HandLeft.animation.CrossFade("Reload");
			RELOADING_LEFT=true;
		}
		
		if(HLC.GetButtonUp(SixenseButtons.BUMPER)){		
			HandLeft.animation.CrossFade("Reload_To_Relax");
			RELOADING_LEFT=false;
			
		}
			
		//Right
		if(HRC.GetButtonDown(SixenseButtons.BUMPER)){
			HandRight.animation.CrossFade("Reload");
			RELOADING_RIGHT=false;
		}
		
		if(HRC.GetButtonUp(SixenseButtons.BUMPER)){		
			HandRight.animation.CrossFade("Reload_To_Relax");
			RELOADING_RIGHT=false;
		
		}
		*/
		//***********************************************************************//
		//************************** GRABBING OBJECTS ******************************//	
		//Left
		/*
		if(HLC.GetButtonDown(SixenseButtons.TRIGGER)){			
			//	Debug.Log ("Grabbing Object");
				HandLeft.animation.CrossFade("Squeeze");
				
		}
		
		if(HLC.GetButtonUp(SixenseButtons.TRIGGER)){
			HandLeft.animation.CrossFade("Squeeze_To_Relax");
		}
		//Right
		if(HRC.GetButtonDown(SixenseButtons.TRIGGER)){
		
			HandRight.animation.CrossFade("Squeeze");
		}
		
		if(HRC.GetButtonUp(SixenseButtons.TRIGGER)){
		
			HandRight.animation.CrossFade("Squeeze_To_Relax");
		}
		
		*/
		
		
		
	}
	
	
	void FixedUpdate(){		
	
		
	}
	
	
}
