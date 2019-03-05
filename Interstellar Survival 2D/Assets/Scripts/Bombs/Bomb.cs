using UnityEngine;
using System.Collections;

public abstract class Bomb : MonoBehaviour {

	public ParticleSystem bomb;
	public AudioClip explosionClip;
	protected float penalty = 0.00f;
	protected Collider2D col2D;
	protected Rigidbody2D rBody2D;


	private void Awake(){
		if(enabled){
			enabled = false;
			Debug.LogWarning(gameObject.name + " was enabled.");
		}

		if(!bomb){
			bomb = GetComponent<ParticleSystem>();
			Debug.LogWarning(gameObject.name + " didn't have the particles attached.");
		}

		col2D = GetComponent<Collider2D>();
		rBody2D = GetComponent<Rigidbody2D>();

		OnAwake();
	}


	protected abstract void OnAwake();


	private void Update(){
		OnUpdate();
	}



	protected abstract void OnUpdate();



	public void Enable(){
		if(Controller.over) return;
		enabled = true;
		col2D.enabled = true;
		WhenEnabled();
	}

	protected virtual void WhenEnabled(){	}


	public virtual void Effect(){	}


	public void Disable(){
		WhenDisabled();
		col2D.enabled = false;
		transform.position = (Vector3.up + Vector3.right) * 200f;
		enabled = false;
	}

	protected virtual void WhenDisabled(){	}
}
