using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemysDetector : MonoBehaviour {

	public Enemy enemy;
	private List<Transform> l_collisions = new List<Transform>();
	private Vector3 collsCenter = Vector3.zero;
	public Collider2D col;


	public void Enable(){
		col.enabled = true;
		enabled = true;
	}

	public void Disable(){
		l_collisions.Clear();
		collsCenter = Vector3.zero;
		col.enabled = false;
		enabled = false;
	}



	private void Update(){
		if(l_collisions.Count == 0 || enemy.IsBurnt()) return;

		foreach(Transform t in l_collisions){
			collsCenter += t.position;
		}

		collsCenter /= l_collisions.Count;

		if(collsCenter.x < transform.position.x){
			// Going right
			enemy.RotateDron('R');
		}
		else{
			// Going left
			enemy.RotateDron('L');
		}
	}


	private void OnTriggerEnter2D(Collider2D c){
		if(c.tag.Equals("Enemy") && !l_collisions.Contains(c.transform)){
			l_collisions.Add(c.transform);
		}
	}


	private void OnTriggerExit2D(Collider2D c){
		if(c.tag.Equals("Enemy")){
			l_collisions.Remove(c.transform);
			if(l_collisions.Count == 0)
				enemy.GoStraight();
		}
	}


	public void ShutDown(){
		col.enabled = false;
	}
}