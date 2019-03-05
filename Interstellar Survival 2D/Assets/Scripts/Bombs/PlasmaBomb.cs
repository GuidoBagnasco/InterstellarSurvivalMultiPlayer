using UnityEngine;
using System.Collections;

public class PlasmaBomb : Bomb {

	public const float VEL = 17.30F;
	protected bool wasActivated = false;



	protected override void OnAwake(){
		penalty = -33.3f;
		enabled = false;
	}


	protected override void OnUpdate(){
		if(Controller.paused) return;
		rBody2D.velocity = transform.up * VEL;
	}



	public override void Effect(){
		enabled = false;
		wasActivated = true;
		col2D.enabled = false;
		bomb.GetComponent<Collider2D>().enabled = true;
		GetComponent<SpriteRenderer>().enabled = false;
		SoundPlayer.Play(explosionClip);
		//transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
		Invoke("Disable", bomb.startLifetime);
		bomb.Emit(1);
	}



	private void OnCollisionEnter2D(Collision2D col){
		if(col.transform.tag.Equals("Enemy") || col.transform.tag.Equals("EnemysProjectile") || col.transform.tag.Equals("PlayersProjectile")){
			bomb.Emit(1);
			wasActivated = true;
		}
	}


	private void OnTriggerEnter2D(Collider2D col){
		if(col.tag.Equals("Enemy")){
			col.GetComponent<Ship>().Invoke("Annihilate", 0.67f);
		}
		else if(col.tag.Equals("EnemysProjectile") || col.tag.Equals("PlayersProjectile")){
			col.GetComponent<Bullet>().Invoke("Break", 0.67f);
		}
	}


	protected override void WhenDisabled(){
		Destroy(gameObject);
	}
}
