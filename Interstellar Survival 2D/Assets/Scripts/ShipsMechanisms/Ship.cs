using UnityEngine;
using System.Collections;

public abstract class Ship : MonoBehaviour {

	public AudioClip cl_shoot;
	public AudioClip cl_explode;

	private float attPower = 27.9f;
	protected abstract void WhenHit(float damage);
	public ParticleSystem explotion;
	protected string colTag = string.Empty;

	protected bool burnt = false;		// Just for enemies.


	public void Hit(float damage = 100f){
		WhenHit(damage);
	}


	protected void Shoot(){
		if(Controller.over || burnt) return;
		OnShoot();
		SoundPlayer.Play(cl_shoot);
	}


	protected virtual void OnShoot(){		}


	protected abstract void OnUpdate();
	
	
	private void Update(){
		OnUpdate();
	}


	private void OnCollisionEnter2D(Collision2D col){
		if(!enabled) return;
		colTag = col.transform.tag;
		if(col.transform.tag.Equals("Player") || col.transform.tag.Equals("Enemy") || col.transform.tag.Equals("Shield")){
			Hit(attPower);
		}
	}



	private void OnTriggerEnter2D(Collider2D col){
		if(!enabled) return;
		// Saves the tag for the time when the bomb calls the destructive function
		colTag = col.tag;
	}



	public virtual void Pause(){	}


	public virtual void Resume(){	}


}
