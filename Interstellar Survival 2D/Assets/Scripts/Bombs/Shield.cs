using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	
	private Animator anim;
	public Transform player;


	private void Start(){
		anim = GetComponent<Animator>();
	}



	private void Update(){
		transform.position = player.position;
	}



	public void Activate(){
		Player.IMMORTAL = true;
		//sRenderer.color = Color.white;
		anim.SetBool("ON", true);
		Invoke("Deactivate", 5.00f);
	}
	

	private void Deactivate(){
		Player.IMMORTAL = false;
		anim.SetBool("ON", false);
	}
}
