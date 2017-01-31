using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour {
	
	public int points=5;
	GameObject ATV;
	Player player;
	public bool P_EFFECT=false;
	public bool IS_HELMET=false;
	public bool IS_TROPHY=false;
	public GameObject effect;
	bool USED=false;
	// Use this for initialization
	void Start () {
		ATV= GameObject.Find("ATV_Rider");
		player = ATV.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime*50, Space.World);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(USED)return;
		
		USED=true;
		audio.Play();
		player.AddPoints(points);
		if(effect){
			Instantiate(effect, transform.position, Quaternion.identity);
			Destroy(gameObject,1.7f);   
		}else{
			Destroy(gameObject,1.7f);   
		}
		
		if(P_EFFECT)player.GoEffect();
		
		if(IS_HELMET){
			player.AddHelmet();
		}else if(IS_TROPHY){
			player.AddTrophy();
		}else{
			player.Coins++;
		}
	}

}
