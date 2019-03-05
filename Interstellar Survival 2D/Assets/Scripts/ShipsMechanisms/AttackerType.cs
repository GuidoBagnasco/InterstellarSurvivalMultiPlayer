using UnityEngine;
using System.Collections;

public abstract class AttackerType : Enemy {

	// Attack variables
	protected float TIME_TO_COOLDOWN;		// Is set in derived classes.
	
	protected Vector2 distanceToAttack = new Vector2(9.00f, 9.00f);


	public Transform[] l_cannons;
	public GameObject bulletPref;
	protected Transform bulletsParent;		// Used to make keep the inspector a little more tidier

	protected bool canAttack = false;




	protected override void OnStart(){
		InvokeRepeating("LaunchRay", TIME_TO_COOLDOWN, TIME_TO_COOLDOWN);
	}


	protected void SearchBulletsParent(){
		bulletsParent = GameObject.FindWithTag("BulletsParent").transform;
	}


	private void LaunchRay(){
		if(!canAttack || Controller.paused) return;
		
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, distanceToAttack.magnitude);
		
		if(hit.collider != null){
			Shoot();
		}
	}
	
	
	
	protected override void OnShoot(){
		foreach(Transform cannon in l_cannons){
			GameObject bullet = Instantiate(bulletPref, cannon.position, cannon.rotation) as GameObject;
			bullet.tag = Controller.ENEMYS_PROJECTILE_TAG;
			bullet.layer = Controller.ENEMYS_PROJECTILE_LAYER;
			bullet.transform.SetParent(bulletsParent);
		}
	}



	protected void ResetCooldown(){
		CancelInvoke("LaunchRay");
		InvokeRepeating("LaunchRay", TIME_TO_COOLDOWN, TIME_TO_COOLDOWN);
	}
}
