using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Explosion explosion;
	public AudioClip clip_normal;
	public AudioClip clip_shielded;

	private const float VEL = 13.30F;
	private string tagToHit_1 = string.Empty;
	private string tagToHit_2 = string.Empty;

	private bool destroyed = false;
	public const float SCORE_BULLET = 31.8f;

	private const int EXP_SCALE_MIN = 8;
	private const int EXP_SCALE_MAX = 10;

	private string colTag = string.Empty;

	private float attPower = 18.6f;

	private float lifetime = 6.50f;

	private Rigidbody2D rBody2D;


	private void Start(){
		rBody2D = GetComponent<Rigidbody2D>();
		Move();
		//Destroy(gameObject, 6.50f);

		switch(transform.tag){
			case Controller.PLAYERS_PROJECTILE_TAG:
				tagToHit_1 = Controller.ENEMYS_TAG;
				tagToHit_2 = Controller.ENEMYS_PROJECTILE_TAG;
					break;
			case Controller.ENEMYS_PROJECTILE_TAG:
				tagToHit_1 = Controller.PLAYERS_TAG;
				tagToHit_2 = Controller.PLAYERS_PROJECTILE_TAG;
				break;
		}
	}



	private void OnTriggerEnter2D(Collider2D col){
		if(destroyed) return;
		if(col.tag.Equals(tagToHit_1)){
			colTag = col.tag;
			col.GetComponent<Ship>().Hit(attPower);
			Break();
		}
		else if(col.tag.Equals(tagToHit_2)){
			colTag = col.tag;
			col.GetComponent<Bullet>().Break();
			Break();
		}
	}



	public void Break(){
		destroyed = true;

		if(Player.IMMORTAL && tagToHit_1.Equals(Controller.PLAYERS_TAG))
			SoundPlayer.Play(clip_shielded);
		else
			SoundPlayer.Play(clip_normal);

		explosion.EmitParticle();

		if(transform.tag.Equals(Controller.ENEMYS_PROJECTILE_TAG)){
			if(colTag.Equals("PlayerProjectile")){
				Score.S.AddScore(SCORE_BULLET);
			}
			else if(colTag.Equals("Bomb")){
				Score.S.AddScore(SCORE_BULLET * Controller.BOMB_PENALTY);
			}
		}
		Destroy(gameObject);
	}



	private void Update(){
		if(Controller.paused) return;

		if(lifetime > 0.00f){
			lifetime -= Time.deltaTime;
		}
		else{
			Destroy(gameObject);
		}
	}



	public void Stop(){
		rBody2D.velocity = Vector2.zero;
	}


	public void Move(){
		rBody2D.velocity = transform.up * VEL;
	}
}
