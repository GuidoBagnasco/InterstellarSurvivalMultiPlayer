using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CargoType : Enemy {
	
	public float speed = 17.00F;
	public float rot_speed = 62.0f;
	
	private bool rotating = false;
	private char rotDir = '0';
	
	public EnemysDetector detector;

	public List<Item> l_items = new List<Item>();
	private int lastItem = -1;



	protected override void OnAwake(){
		enemyType = TYPE.Ship;
	}


	protected override void OnStart(){		}


	protected override void WhenEnabled(){
		Invoke("Restore", 20f);
		col2D.enabled = true;
		detector.Enable();
		if(lastItem > 0 && l_items[lastItem].isActive){
			l_items[lastItem].Disable();
			lastItem = -1;
		}
	}
	

	
	protected override void OnUpdate(){
		if(burnt) return;
		
		transform.Translate(Vector3.up * Time.deltaTime * speed);
	}
	
	
	private void FixedUpdate(){
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
		if(destroyedByPlayer) DropItem();
		CancelInvoke("Restore");
		GoStraight();
		col2D.enabled = false;
		detector.Disable();
	}


	private void DropItem(){
		lastItem = Random.Range(0, l_items.Count);
		l_items[lastItem].Enable();
	}


	protected override void OnShutDown(){
		detector.ShutDown();
	}
}
