using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletsParent : MonoBehaviour {

	private List<Bullet> l_bullets = new List<Bullet>();



	private void Pause(){
		for(int i = 0; i < transform.childCount; i ++){
			l_bullets.Add(transform.GetChild(i).GetComponent<Bullet>());
			l_bullets[i].Stop();
		}
	}
	

	public void Resume(){
		foreach(Bullet b in l_bullets){
			b.Move();
		}
	}
}
