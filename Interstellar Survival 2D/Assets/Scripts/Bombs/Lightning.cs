using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lightning : MonoBehaviour {

	private Animator anim;
	public Transform player;
	public AudioClip clip;

	private const float DELAY = 4.30f;
	private float timer = 0.00f;



	private void Awake(){
		anim = GetComponent<Animator>();
	}

	
	public void Activate(){
		Controller.Burnt = true;

		timer = DELAY;
		transform.position = player.position;
		anim.Play("Lightning");
		SoundPlayer.Play(clip);

		enabled = true;
	}




	private void Update(){
		if(Controller.paused)
			return;

		if(timer > 0.00f){
			timer -= Time.deltaTime;
		}
		else{
			TurnOff();
		}
	}



	private void OnTriggerEnter2D(Collider2D col){
		Enemy enemy = col.GetComponent<Enemy>();
		if(EnemySpawner.ES.l_used.Contains(enemy)){
			enemy.Burn();
		}
	}


	public void TurnOff(){
		foreach(Enemy enemy in EnemySpawner.ES.l_used){			
			enemy.BurnHeal();
		}
		Controller.Burnt = false;

		enabled = false;
	}
}
