using UnityEngine;
using System.Collections;

public class EnemyShip : AttackerType {
	
	public float speed = 0.00f;
	public float rot_speed = 0.00f;
	
	private bool rotating = false;
	private char rotDir = '0';

	public EnemysDetector detector;



	protected override void OnAwake(){
		enemyType = TYPE.Ship;
	}



	protected override void OnStart(){
		TIME_TO_COOLDOWN = 1.50F;
		distanceToAttack = new Vector2(26.0f, 15.0f);
		SearchBulletsParent();
		base.OnStart();
	}



	protected override void WhenEnabled(){
		Invoke("Restore", 20f);
		col2D.enabled = true;
		detector.Enable();
		ResetCooldown();
	}



	protected override void OnUpdate(){
		if(burnt) return;

		transform.Translate(Vector3.up * Time.deltaTime * speed);

		if(transform.position.x <= distanceToAttack.x && transform.position.y <= distanceToAttack.y){
			canAttack = true;
		}
	}



	private void FixedUpdate(){
		if(burnt) return;

		if(rotating) RotateDron(rotDir);
	}


	
	
	public override void RotateDron(char d){
		rotating = true;
		rotDir = d;
		switch(d){
			case 'L':
				transform.Rotate(Vector3.forward, -rot_speed * Time.deltaTime);
				break;
			case 'R':
				transform.Rotate(Vector3.forward, rot_speed * Time.deltaTime);
				break;
		}
	}
	


	public override void GoStraight(){
		rotating = false;
		rotDir = '0';
	}



	protected override void WhenRestored(){
		CancelInvoke("Restore");
		GoStraight();
		ResetCooldown();
		col2D.enabled = false;
		canAttack = false;
		detector.Disable();
	}



	public override void Pause(){
		enabled = false;
	}



	public override void Resume(){
		enabled = true;
	}



	protected override void OnShutDown(){
		detector.ShutDown();
		enabled = false;
	}
}
