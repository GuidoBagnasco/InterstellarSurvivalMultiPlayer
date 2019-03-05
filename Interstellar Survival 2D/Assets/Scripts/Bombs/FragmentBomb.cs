using UnityEngine;
using System.Collections;

public class FragmentBomb : Bomb {
	
	private bool hit = false;



	protected override void OnAwake(){
		penalty = -15.7f;
	}
	
	
	protected override void OnUpdate(){
		rBody2D.velocity = transform.up * DivisibleBomb.VEL;
	}	
	
	
	private void OnTriggerEnter2D(Collider2D col){
		if(col.tag.Equals("Enemy")){
			col.GetComponent<Ship>().Invoke("Annihilate", 0.07f);
			PrepareForExplosion();
		}
		else if(col.tag.Equals("EnemysProjectile") || col.tag.Equals("PlayersProjectile")){
			col.GetComponent<Bullet>().Invoke("Break", 0.07f);
			PrepareForExplosion();
		}
	}


	private void PrepareForExplosion(){
		if(!hit){
			hit = true;
			bomb.Play();
			Disable();
			SoundPlayer.Play(explosionClip);
		}
	}
	
	
	protected override void WhenDisabled(){
		enabled = true;
		bomb.transform.SetParent(null);
		Destroy(bomb.gameObject, 3.00f);
		Destroy(gameObject);
	}
}
