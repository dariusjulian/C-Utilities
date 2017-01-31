using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour {

	public float sensitivityX = 15.0f;
	public float sensitivityY = 15.0f;
	public float RotThresh= 25f;
	private Transform cameraTm;
	
	private bool mdown = false;
	private bool tdown = false;

	private float startX = 0;
	private float startY = 0;
	private float currX = 0;
	private float currY = 0;
	public float OrigScale = 1;
	public StationCamera cam;
	public bool IS_TOUCH=true;

	public bool IS_ACTIVE=false;

	//Floating Vars
	private DepthOfFieldScatter DOF;
	public float horizontalSpeed=0;
	public float verticalSpeed=2f;
	public float amplitude= .05f;
	public bool IS_FLOATING=true;
	private Vector3 tempPosition;
	public GameObject effect;
	public bool ANIMATE_3=false;
	public bool ANIMATE_5=false;
	public bool SPINS=false;
	public ObjectSpinner spinner;
	public Greeble_3_Animator animator_3;
	public Greeble_5_Animator animator_5;
	public AudioClip sfx_effect;

	// Use this for initialization
	void Start ()
	{
		tempPosition = transform.position;
		cam=GameObject.Find ("Station Camera").GetComponent<StationCamera>();
		DOF=cam.gameObject.GetComponent<DepthOfFieldScatter>();
		cameraTm = GameObject.Find ("Station Camera").transform;
		OrigScale=gameObject.transform.localScale.y;
		effect= transform.FindChild("effect").gameObject;

		if(ANIMATE_3){
			animator_3= gameObject.GetComponent<Greeble_3_Animator>();
			Debug.Log(animator_3);
		}
		
		if(ANIMATE_5){
			animator_5= gameObject.GetComponent<Greeble_5_Animator>();
			Debug.Log(animator_5);
		}

		if(SPINS){
			spinner=  gameObject.GetComponent<ObjectSpinner>();
			Debug.Log("This is spinner: "+spinner);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!IS_ACTIVE)return;
		//Debug.Log("ROTATOR");
		float rotationX;
		float rotationY;
		float mouseX;
		float mouseY;

		float sh = Screen.height;
		if(Input.mousePosition.x<100||Input.mousePosition.y<120||Input.mousePosition.y>sh-120)return;
		//****************************************************************************************//
	
			if( Input.GetMouseButtonDown( 0 ) ){
			//	Debug.Log("Mousing "+Input.mousePosition.x);
				startX=Input.mousePosition.x;
				startY=Input.mousePosition.y;

				mdown = true;
			}else if( Input.GetMouseButtonUp( 0 ) ){
				//	cam.header.SendMessage("");
				mdown = false;
				
			}
			
			if( mdown )
			{
			//	Debug.Log("MouseX "+Input.mousePosition.x);
				//if(Input.mousePosition.x<100)return;
				currX=Input.mousePosition.x;
				mouseX= (currX-startX)/RotThresh;
				
				currY=Input.mousePosition.y;
				mouseY= (currY-startY)/RotThresh;

				startY=currY;
				startX=currX;

				rotationX = mouseX * sensitivityX;
				rotationY = mouseY * sensitivityY;
				transform.RotateAroundLocal( cameraTm.up, -Mathf.Deg2Rad * rotationX );
				transform.RotateAroundLocal( cameraTm.right, Mathf.Deg2Rad * rotationY );
			}

	}

	void FixedUpdate () 
	{
		if(!IS_ACTIVE)return;

		//if(IS_FLOATING){
			tempPosition.x += horizontalSpeed;
			tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed)* amplitude+1f;
			transform.position = tempPosition;
		//}else{
		//	transform.Rotate(0, Time.deltaTime*-40f, 0);
	//	}
	}

	public void GoEffect(bool i=true){
		if(ANIMATE_3){
			if(cam.IS_ZOOMED)return;
			if(i){			
				AdjustDOF(true);
				animator_3.AnimateIn();
			}else{	
				AdjustDOF(false);
				animator_3.AnimateOut();
			}
		}else if(ANIMATE_5){
			if(cam.IS_ZOOMED)return;
			if(i){			
				AdjustDOF(true);
				audio.Stop();
				effect.SetActive(false);
				animator_5.AnimateIn();
			}else{	
				AdjustDOF(false);
				audio.Play();
				effect.SetActive(true);
				animator_5.AnimateOut();
			}
		}else if(SPINS){
			if(!i){
				spinner.SPINNING=true;
			}else{
				spinner.SPINNING=false;
			}
		}else{
			if(!i){
				audio.Play();
				effect.SetActive(true);
			}else{
				audio.Stop();
				effect.SetActive(false);
			}
		}

	}

	public void AdjustDOF(bool IN){
		if(IN){
			if(!cam.LABELS_SHOWING){
				DOF.focalLength=10f;
				DOF.aperture=30f;
				DOF.focalSize=.5f;
				cam.IS_EXPLODED=false;
			}
		}else{
			DOF.focalLength=10f;
			DOF.aperture=15f;
			DOF.focalSize=2f;
			cam.IS_EXPLODED=true;
		}
	}

	public void GoReset(){
		if(ANIMATE_3)animator_3.AnimateIn();
		if(ANIMATE_5)animator_5.AnimateIn();
		if(SPINS)spinner.SPINNING=false;
		effect.SetActive(false);
		if(audio.isPlaying)
			audio.Stop();
		IS_FLOATING=true;
		Vector3 rotAmount =  new Vector3(0,0,0);
		//	transform.localRotation= new Quaternion(0,0,0,0);
		iTween.RotateTo(gameObject, iTween.Hash("rotation", rotAmount, "time", 1f));
		Vector3 scAmount =  new Vector3(1,1,1);
		iTween.ScaleTo(gameObject, iTween.Hash("scale", scAmount, "time", 1f));
	}
}
