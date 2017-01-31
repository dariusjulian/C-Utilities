using UnityEngine;
using System.Collections;

public class Rov_Path : MonoBehaviour {

	// Use this for initialization
	public int[] pArray1;
	public int[] pArray2;
	public int[] pArray3;
	public int[] pArray4;
	public int[] pArray5;
	private int cnt=0;
	
	void Start () {
		pArray1= new int[5];
		pArray1[0]=-494;
		pArray1[1]=	122;
		pArray1[2]=-882;
		pArray1[3]=77;
		pArray1[4]=8;
		pArray2= new int[5];		
		pArray2[0]=1065;
		pArray2[1]=	44;
		pArray2[2]=-1602;
		pArray2[3]=77;
		pArray2[4]=7;
		pArray3= new int[5];		
		pArray3[0]=359;
		pArray3[1]=	103;
		pArray3[2]=-290;
		pArray3[3]=14;
		pArray3[4]=8;
		pArray4= new int[5];		
		pArray4[0]=1065;
		pArray4[1]=	44;
		pArray4[2]=-1602;
		pArray4[3]=83;
		pArray4[4]=6;
		pArray5= new int[5];		
		pArray5[0]=-146;
		pArray5[1]=	88;
		pArray5[2]=-2595;
		pArray5[3]=155;
		pArray5[4]=10;
		
		GoMoveMent();
	}
	
	void GoMoveMent(){
		cnt++;
		if(cnt>5)cnt=1;
		switch(cnt){
		case 1: 
			iTween.MoveTo(gameObject, iTween.Hash("x", pArray1[0], "y", pArray1[1], "z",pArray1[2], "time", pArray1[4], "delay", 1.5f));
			iTween.RotateTo(gameObject, iTween.Hash("y", pArray1[3], "time", pArray1[4], "delay", 1.5f, "oncomplete","GoMoveMent"));
			break;
		case 2: 
			iTween.MoveTo(gameObject, iTween.Hash("x", pArray3[0], "y", pArray3[1], "z",pArray3[2], "time", pArray3[4], "delay", 1.5f));
			iTween.RotateTo(gameObject, iTween.Hash("y", pArray3[3], "time", pArray3[4], "delay", 1.5f, "oncomplete","GoMoveMent"));
			break;
		case 3: 
			iTween.MoveTo(gameObject, iTween.Hash("x", pArray4[0], "y", pArray4[1], "z",pArray4[2], "time", pArray4[4], "delay", 3f));
			iTween.RotateTo(gameObject, iTween.Hash("y", pArray4[3], "time", pArray4[4], "delay", 3f, "oncomplete","GoMoveMent"));
			break;
		case 4: 
			iTween.MoveTo(gameObject, iTween.Hash("x", pArray2[0], "y", pArray2[1], "z",pArray2[2], "time", pArray2[4], "delay", 0f));
			iTween.RotateTo(gameObject, iTween.Hash("y", pArray2[3], "time", pArray2[4], "delay", 0f, "oncomplete","GoMoveMent"));
			break;
		case 5: 
			iTween.MoveTo(gameObject, iTween.Hash("x", pArray5[0], "y", pArray5[1], "z",pArray5[2], "time", pArray5[4], "delay", 2f));
			iTween.RotateTo(gameObject, iTween.Hash("y", pArray5[3], "time", pArray5[4], "delay", 2f, "oncomplete","GoMoveMent"));
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
