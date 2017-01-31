using UnityEngine;
using System.Collections;

public class ObjectSpinner : MonoBehaviour {

	public bool SPINNING=false;
	public GameObject Spinner;

	// Use this for initialization
	void Start () {
		//Spinner=transform.FindChild("spinner").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(SPINNING){
			Debug.Log("IM SPINNING AWAY");
			Spinner.transform.Rotate(0,0,Time.deltaTime*200f);
		}
	}
}
