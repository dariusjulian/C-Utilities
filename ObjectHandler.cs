using UnityEngine;
using System.Collections;

public class ObjectHandler : MonoBehaviour {
	
	public float sensitivityX = 1.0f;
	public float sensitivityY = 1.0f;
	private Transform cameraTm;

	
	// Use this for initialization
	void Start ()
	{
		cameraTm = Camera.mainCamera.transform;
	}
	
	// Update is called once per frame
	public void OnRotate (int vx, int vy) {
	
			if(vx<100)return;
			
			Debug.Log ("MouseX: "+vx);
			float rotationX = vx * sensitivityX;
			float rotationY = vy * sensitivityY;
			transform.RotateAroundLocal( cameraTm.up, -Mathf.Deg2Rad * rotationX );
			transform.RotateAroundLocal( cameraTm.right, Mathf.Deg2Rad * rotationY );

		
		
	}
}