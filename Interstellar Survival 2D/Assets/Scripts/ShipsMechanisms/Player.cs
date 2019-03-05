using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Ship {

	private const float SPEED_BOOST = 0.85F;
	private float speed = 5.00f;
	public Transform[] cannons;
	public List<Transform>[] l_cannons = new List<Transform>[3];
	public GameObject bulletPref;
	public GameObject divisiblePref;
	public GameObject plasmaPref;
	private Transform bulletsParent;		// Used to make keep the inspector a little more tidier

	private float TimeToShoot = 0.70f;
	private int cannonsInUse = 0;

	public Health health;
	public PowsManager powsManager;

	[HideInInspector]
	public Vector3 posToMove = Vector3.zero;

	public static bool IMMORTAL = false;
	public static bool USE_DIVISIBLE_BOMB = false;
	public static bool USE_PLASMA_BOMB = false;

	public static bool notUpgraded = true;
	public AudioClip clip_upgrade;
	public AudioClip clip_downgrade;
	public ParticleSystem p_upgrade;
	public ParticleSystem p_downgrade;

	private Collider2D col2D;
	private SpriteRenderer sRenderer;

	private Vector3 camLimits;



	private void Awake(){
		// Sets list cause this can't be done in editor
		l_cannons[0] = new List<Transform>();
		l_cannons[0].Add(cannons[0]);
		l_cannons[0].Add(cannons[1]);

		l_cannons[1] = new List<Transform>();
		l_cannons[1].Add(cannons[0]);
		l_cannons[1].Add(cannons[1]);
		l_cannons[1].Add(cannons[2]);

		l_cannons[2] = new List<Transform>();
		l_cannons[2].Add(cannons[0]);
		l_cannons[2].Add(cannons[1]);
		l_cannons[2].Add(cannons[2]);
		l_cannons[2].Add(cannons[3]);
		l_cannons[2].Add(cannons[4]);


		col2D = GetComponent<Collider2D>();
		sRenderer = GetComponent<SpriteRenderer>();

		IMMORTAL = false;
		USE_DIVISIBLE_BOMB = false;
    	USE_PLASMA_BOMB = false;
	}


	private void Start(){
		bulletsParent = GameObject.FindWithTag("BulletsParent").transform;
		InvokeRepeating("Shoot", 0.10f, TimeToShoot);
		notUpgraded = true;

		camLimits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -Camera.main.transform.position.z));
	}


	public void Reset(){
		TimeToShoot = 0.70f;
	}


	protected override void OnShoot(){
		if(USE_DIVISIBLE_BOMB){
			GameObject dB = Instantiate(divisiblePref, cannons[2].position + Vector3.back, transform.rotation) as GameObject;		// Central cannon
			dB.GetComponent<DivisibleBomb>().Enable();
			USE_DIVISIBLE_BOMB = false;

		}
		if(USE_PLASMA_BOMB){
			GameObject pB = Instantiate(plasmaPref, cannons[2].position + Vector3.back, transform.rotation) as GameObject;		// Central cannon
			pB.GetComponent<PlasmaBomb>().Enable();
			USE_PLASMA_BOMB = false;
		}else{
			foreach(Transform cannon in l_cannons[cannonsInUse]){
				GameObject bullet = Instantiate(bulletPref, cannon.position, cannon.rotation) as GameObject;
				bullet.tag = Controller.PLAYERS_PROJECTILE_TAG;
				bullet.layer = Controller.PLAYERS_PROJECTILE_LAYER;
				bullet.transform.SetParent(bulletsParent);
			}
		}
	}



	public void VaryShootingSpeed(bool faster){
		if(faster)
			TimeToShoot -= 0.15f;
		else
			TimeToShoot += 0.15f;

		if(TimeToShoot < 0.30f) TimeToShoot = 0.30f;
		CancelInvoke("Shoot");
		InvokeRepeating("Shoot", 0.10f, TimeToShoot);
	}



	public void VaryRange(bool add){
		if(add){
			if(cannonsInUse < l_cannons.Length-1) cannonsInUse++;
		}
		else{
			if(cannonsInUse > 0) cannonsInUse--;
		}
	}


	public void VarySpeed(bool accelerate){
		if(accelerate){
			speed += SPEED_BOOST;
		}
		else{
			speed -= SPEED_BOOST;
		}
	}


	public void MoveToPos(Vector3 pos){
		posToMove = pos;
		Vector3 diff = pos - transform.position;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}



	protected override void OnUpdate(){
		if(Controller.paused) return;

		if((posToMove - transform.position).magnitude > 0.60f)
			transform.Translate(Vector3.up * speed * Time.deltaTime);

		if(transform.position.x > camLimits.x)
			transform.position = new Vector3(camLimits.x, transform.position.y, transform.position.z);

		if(transform.position.x < -camLimits.x)
			transform.position = new Vector3(-camLimits.x, transform.position.y, transform.position.z);

		if(transform.position.y > camLimits.y)
			transform.position = new Vector3(transform.position.x, camLimits.y, transform.position.z);

		if(transform.position.y < -camLimits.y)
			transform.position = new Vector3(transform.position.x, -camLimits.y, transform.position.z);
	}



	protected override void WhenHit(float damage){
		if(IMMORTAL) return;
		health.DamageTaken(damage);
		powsManager.PlayerHit();
	}


	public void ShipsStatsChanges(bool improve){
		if(improve){
			p_upgrade.Emit(20);
			SoundPlayer.Play(clip_upgrade);
		}
		else if(!notUpgraded){
			p_downgrade.Emit(20);
			SoundPlayer.Play(clip_downgrade);
		}
	}


	public void Explode(){
		enabled = false;
		CancelInvoke("Shoot");
		SoundPlayer.Play(cl_explode);
		explotion.Play();
		col2D.enabled = false;
		Invoke("VanquishShip", 0.13f);
	}


	private void VanquishShip(){
		sRenderer.enabled = false;
	}


	public override void Pause(){
		enabled = false;
		CancelInvoke("Shoot");
	}


	public override void Resume(){
		enabled = true;
		InvokeRepeating("Shoot", 0.10f, TimeToShoot);
	}
}
