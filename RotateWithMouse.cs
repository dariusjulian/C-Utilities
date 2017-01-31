using UnityEngine;
using System.Collections;

public class RotateWithMouse : MonoBehaviour {
	
	public float sensitivityX = 15.0f;
	public float sensitivityY = 15.0f;
	private Transform cameraTm;
	
	private bool mdown = false;
	private bool tdown = false;
	public StationCamera cam;
	public bool IS_TOUCH=true;
	// Use this for initialization
	void Start ()
	{
		cam=GameObject.Find ("Station Camera").GetComponent<StationCamera>();
		cameraTm = GameObject.Find ("Station Camera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("ROTATOR");
		float rotationX;
		float rotationY;
		float mouseX;

		//****************************************************************************************//
		if(!IS_TOUCH){
			if( Input.GetMouseButtonDown( 0 ) ){
				Debug.Log("Mousing "+Input.mousePosition.x);
				cam.header.SendMessage("mousing");
				mdown = true;
			}else if( Input.GetMouseButtonUp( 0 ) ){
			//	cam.header.SendMessage("");
				mdown = false;

			}

			if( mdown )
			{
				Debug.Log("MouseX "+Input.mousePosition.x);
				//if(Input.mousePosition.x<100)return;
				mouseX=Input.GetAxis("Mouse X");
		
				cam.header.SendMessage("mousing "+mouseX);
				rotationX = mouseX * sensitivityX;
				rotationY = Input.GetAxis("Mouse Y") * sensitivityY;
				transform.RotateAroundLocal( cameraTm.up, -Mathf.Deg2Rad * rotationX );
				transform.RotateAroundLocal( cameraTm.right, Mathf.Deg2Rad * rotationY );
			}
		}else{
		//****************************************************************************************//
			if( Input.touchCount>0 ){
				Debug.Log("touching "+Input.mousePosition.x);
				cam.header.SendMessage("touching");
				tdown = true;
			}else{
		//		cam.header.SendMessage("");
				tdown = false;
				
			}

			if( tdown )
			{
				Debug.Log("TouchX "+Input.mousePosition.x);
				//if(Input.GetTouch(0).position.x<100)return;
				mouseX=Input.GetTouch(0).deltaPosition.x;
				cam.header.SendMessage("touching "+mouseX);
			
				rotationX = mouseX * sensitivityX;
				rotationY = Input.GetTouch(0).deltaPosition.y * sensitivityY;
				transform.RotateAroundLocal( cameraTm.up, -Mathf.Deg2Rad * rotationX );
				transform.RotateAroundLocal( cameraTm.right, Mathf.Deg2Rad * rotationY );
			}
		}
	}
}