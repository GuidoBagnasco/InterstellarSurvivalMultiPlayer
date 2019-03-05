using UnityEngine;
using System.Collections;

public class Cursor : ObjectSprite {

	public Player player;
	public Animator anim;
	private bool isSeen = false;




	protected override void OnStart(){
		if(anim == null){
			anim = GetComponent<Animator>();
			Debug.LogWarning(gameObject.name + " didn't have the animator assigned.");
		}
	}


	public void Apparate(Vector3 point){
		point.z = -Camera.main.transform.position.z;
		col2D.enabled = true;
		transform.position = Camera.main.ScreenToWorldPoint(point);
		Activate();
		isSeen = true;
		Enable();
		anim.SetBool("Play", true);
	}


	public void Disapparate(){
		anim.SetBool("Play", false);
		col2D.enabled = false;
		isSeen = false;
		Disable();
	}


	public bool IsSeen(){
		return isSeen;
	}


	protected override void Activate(){
		sRenderer.enabled = true;
	}


	protected override void Deactivate(){
		sRenderer.enabled = false;
	}


	private void OnTriggerEnter2D(Collider2D col){
		if(col.tag.Equals("Player")){
			Disapparate();
		}
	}
}
