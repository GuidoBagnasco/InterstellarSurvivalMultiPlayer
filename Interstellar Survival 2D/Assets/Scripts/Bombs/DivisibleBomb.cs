using UnityEngine;
using System.Collections;

public class DivisibleBomb : Bomb {

	public const float VEL = 17.30F;
	private const int QUANTITY = 5;
	private bool normalSize = true;

	public GameObject fragmentPref;



	protected override void OnAwake(){
		penalty = -15.7f;
		Invoke("Disable", 4.50f);
	}


	protected override void OnUpdate(){
		if(Controller.paused) return;
		rBody2D.velocity = transform.up * VEL;
	}


	public override void Effect(){
		for(short i = 0; i < QUANTITY; i++){
			GameObject fragment = Instantiate(fragmentPref, transform.position, Quaternion.identity) as GameObject;
			//fragment.transform.Rotate(transform.forward, 120.0f - (240.0f * i / QUANTITY));
			fragment.transform.Rotate(transform.eulerAngles + Vector3.forward * (120.0f - 240.0f*i/(QUANTITY-1)));
			fragment.GetComponent<FragmentBomb>().Enable();
		}

		Disable();
	}



	private void OnTriggerEnter2D(Collider2D col){
		if(col.tag.Equals("Enemy")){
			Expand();
			SoundPlayer.Play(explosionClip);
			col.GetComponent<Ship>().Invoke("Annihilate", 0.07f);
		}
		else if(col.tag.Equals("EnemysProjectile") || col.tag.Equals("PlayersProjectile")){
			SoundPlayer.Play(explosionClip);
			col.GetComponent<Bullet>().Invoke("Break", 0.07f);
		}
	}


	private void Expand(){
		if(normalSize){
			transform.localScale *= 2.00f;
			normalSize = false;
			bomb.Play();
			Invoke("Disable", 0.21f);
		}
	}


	protected override void WhenDisabled(){
		enabled = true;
		bomb.transform.SetParent(null);
		Destroy(bomb.gameObject, 3.00f);
		Destroy(gameObject);
	}
}
