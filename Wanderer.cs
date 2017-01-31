using UnityEngine;
using System.Collections;

public class Wanderer: MonoBehaviour {
	
	public NavMeshAgent agent;
	
	Vector3 aTarget;
	Vector3 Pos;
	int Thresh=0;
	public float BO;
	
	void Start () {		
		Pos=gameObject.transform.position;
		agent.baseOffset=BO;
		aTarget= new Vector3(Random.Range(-21, 25), 0, Random.Range(-11,22 ));
		agent.SetDestination(aTarget);
	}
	
	void Update () {
		bool Stuck=false;
		if(Pos==gameObject.transform.position){
			//	Debug.Log("I'm Might be STUCK!! "+gameObject.name);
			Thresh++;
			if(Thresh>20){
		//		Debug.Log("I'm STUCK!!");
				Stuck=true;
				Thresh=0;
			}
		}
		Pos=gameObject.transform.position;
	   if(Vector3.Distance(transform.position, aTarget) < 1||Stuck){
		//	Debug.Log("Getting new target");
    	   aTarget= new Vector3(Random.Range(-21, 25), 0, Random.Range(-11,22 ));
			
	   }
		
		
		agent.destination = aTarget;
		
	}
}
 
 