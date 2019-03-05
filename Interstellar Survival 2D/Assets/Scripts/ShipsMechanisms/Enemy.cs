using UnityEngine;
using System.Collections;

public abstract class Enemy : Ship {
	
	protected bool mayRotate = true;

	[HideInInspector]
	public Transform player;
	



	public enum TYPE{
		Unknown = 0,
		Ship = 1,
		Dron = 2
	}


	protected TYPE enemyType;
	public float score;
	
	public float fullHP;
	private float hp;

	protected bool destroyedByPlayer = false;
	protected Collider2D col2D;
	protected SpriteRenderer sRenderer;

	protected bool readyToUse = true;		// For enemies that drop items.
	

	protected abstract void OnAwake();


	private void Awake(){
		if(enabled){
			Debug.LogWarning(transform.name + " was on!");
			enabled = false;
		}

		col2D = GetComponent<Collider2D>();
		sRenderer = GetComponent<SpriteRenderer>();
		OnAwake();
	}


	protected abstract void OnStart();


	private void Start(){
		OnStart();
		hp = fullHP;
	}


	protected abstract void WhenEnabled();


	public void OnEnable(){
		if(!readyToUse) return;
		Vector3 diff = player.position - transform.position;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

		explotion.transform.SetParent(transform);
		explotion.transform.localPosition = Vector3.zero;

		WhenEnabled();
	}



	public TYPE GetEnemyType(){
		return enemyType;
	}



	protected override void WhenHit(float damage){
		hp -= damage;

		if(hp > 0.00f) return;
		SpecialFunction();
		explotion.transform.SetParent(null);
		explotion.Emit(3);
		if(!colTag.Equals("Enemy")){
			destroyedByPlayer = true;
			Score.S.AddScore(score);
			Score.S.EnemyDown();
		}
		else{
			destroyedByPlayer = false;
		}
		SoundPlayer.Play(cl_explode);
		Invoke("Restore", 0.10f);
	}


	protected virtual void SpecialFunction(){	}



	protected abstract void WhenRestored();


	protected void Restore(){
		enabled = false;
		mayRotate = true;
		hp = fullHP;
		BurnHeal();
		transform.eulerAngles = Vector3.zero;
		WhenRestored();
		destroyedByPlayer = false;
		EnemySpawner.ES.StoreShip(this);
	}



	// Methods for movements
	public virtual void GoStraight(){		}

	public virtual void RotateDron(char d = 's'){		}
	


	public bool IsBurnt(){
		return burnt;
	}


	public void Burn(){
		burnt = true;
		sRenderer.color = new Color(0.2873f, 0.2873f, 0.2873f, 1.00f);
	}


	public void BurnHeal(){
		burnt = false;
		if(sRenderer)
			sRenderer.color = Color.white;
	}


	public void Annihilate(){
		destroyedByPlayer = true;
		explotion.transform.SetParent(null);
		explotion.Emit(3);
		Score.S.AddScore(score * Controller.BOMB_PENALTY);
		Score.S.EnemyDown();
		Restore();
	}


	public void ShutDown(){
		OnShutDown();
		GoStraight();
	}


	protected virtual void OnShutDown(){	}

}
