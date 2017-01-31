using UnityEngine;
using System.Collections;

public class NonNavWanderer : MonoBehaviour {
	
	Vector3 aTarget;
	Vector3 Pos;
	int Thresh=0;
	public float Speed=2;
	public float MinZ=33f;
	public float MaxZ=51f;
	public float MinX=28f;
	public float MaxX=-33f;
	public float RotationSpeed;
 
    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;
	
	
	void Start () {		
		Pos=gameObject.transform.position;
		
		aTarget= GetNewTarget();
		
	}
	
	void Update () {
		bool Stuck=false;
		if(Pos==gameObject.transform.position){
				Debug.Log("I'm Might be STUCK!! "+gameObject.name);
			Thresh++;
			if(Thresh>20){
				Debug.Log("I'm STUCK!!");
				Stuck=true;
				Thresh=0;
			}
		}
		
		Pos=gameObject.transform.position;
		
		transform.position += transform.TransformDirection(Vector3.forward)*Speed*Time.deltaTime;
		
	   if(Vector3.Distance(transform.position, aTarget) < 1||Stuck){
			Debug.Log("Getting new target");
    	 aTarget=  GetNewTarget();
		
	   }
		
		_direction = (aTarget - transform.position).normalized;
 
       //create the rotation we need to be in to look at the target
       _lookRotation = Quaternion.LookRotation(_direction);
 
       //rotate us over time according to speed until we are in the required rotation
       transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		
		
		
	}
	
	Vector3 GetNewTarget(){
		return new Vector3(Random.Range(MinX, MaxX), Random.Range(4,10), Random.Range(MinZ,MaxZ ));
	}
}
