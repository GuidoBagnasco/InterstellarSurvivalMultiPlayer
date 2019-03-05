using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour {

	public Enemy ship;

	private const float SPEED = 4.30F;


	protected static Health player;
	public AudioClip clip_grabbed;

	protected SpriteRenderer sRenderer;
	private Rigidbody2D rBody2D;
	private Color transparent = new Color(1.00f, 1.00f, 1.00f, 0.00f);

	[HideInInspector]
	public bool isActive = false;

	private float timer = 0.00f;
	private const float TIME_TO_DISSAPEAR = 4.00F;
	private Animator anim;



	private void Awake(){
		if(player == null){
			player = EnemySpawner.ES.player.GetComponent<Health>();
		}

		sRenderer = GetComponent<SpriteRenderer>();
		rBody2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}



	public void Enable(){
		// Turn on mechanism
		gameObject.SetActive(true);
		transform.position = ship.transform.position;
		transform.SetParent(null);
		rBody2D.isKinematic = false;
		WhenEnabled();
		enabled = true;
		isActive = true;
	}



	protected virtual void WhenEnabled(){	}


	private void Update(){
		if(Controller.paused) return;

		if(timer < TIME_TO_DISSAPEAR){
			timer += Time.deltaTime;
		}
		else{
			anim.SetBool("Dissapearing", true);
		}
		//rBody2D.velocity = (EnemySpawner.ES.player.transform.position - transform.position) * SPEED;
		//transform.Translate((EnemySpawner.ES.player.transform.position - transform.position) * SPEED * Time.deltaTime);
	}


	private void OnTriggerEnter2D(Collider2D col){
		if(enabled && col.tag.Equals("Player")){
			Grabbed();
		}
	}


	private void Grabbed(){
		SoundPlayer.Play(clip_grabbed);
		WhenGrabbed();
		Disable();
	}


	protected abstract void WhenGrabbed();



	public void Disable(){
		if(!isActive) return;
		isActive = false;
		enabled = false;
		rBody2D.isKinematic = true;
		sRenderer.color = transparent;
		anim.SetBool("Dissapearing", false);
		transform.SetParent(ship.transform);
		transform.localPosition = Vector3.zero;
		timer = 0.00f;
		gameObject.SetActive(false);
	}
}
