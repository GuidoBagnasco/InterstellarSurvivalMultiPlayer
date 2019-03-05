using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public const string PLAYERS_TAG = "Player";
	public const string ENEMYS_TAG = "Enemy";
	public const string PLAYERS_PROJECTILE_TAG = "PlayersProjectile";
	public const string ENEMYS_PROJECTILE_TAG = "EnemysProjectile";
	public const int PLAYERS_PROJECTILE_LAYER = 9;
	public const int ENEMYS_PROJECTILE_LAYER = 13;
	public const float BOMB_PENALTY = 0.80F;

	public const float OFFSET_SHIP = 35.00f;
	public const float OFFSET_DRON = 8.00f;

	public static Vector2 screenLimits = Vector3.zero;

	public static bool Burnt = false;


	public static bool over = false;
	public static bool paused = false;

	public Player player;
	public SpawnerController spController;
	public PopManager overPop;
	private Rigidbody2D[] l_rigidbodies;
	private Vector3[] l_velocities;
	public PowsManager pow_manager;

	public PopManager bombs_buttons;
	public PauseButton button_pause;

	public Curtain curtain;



	private void Awake(){
		over = false;
		Burnt = false;

		Controller.paused = true;
		button_pause.TurnOff();
		paused = true;
		
		//EnemySpawner.ES.ShutDown();
		spController.enabled = false;
		
		player.Pause();
	}
	

	private void Start(){
		screenLimits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.95f, Screen.height * 0.85f, 0.00f));
	}



	public void StartGame(){
		curtain.StartUp();
		OnResume();
	}


	private void RefreshList(){
		l_rigidbodies = FindObjectsOfType<Rigidbody2D>();
		l_velocities = new Vector3[l_rigidbodies.Length];
	}
	
	
	
	public void OnPause(){
		if(Controller.over || Controller.paused) return;

		button_pause.TurnOff();
		paused = true;
		RefreshList();
		int i = 0;
		foreach(Rigidbody2D R in l_rigidbodies){
			l_velocities[i++] = R.velocity;
			R.isKinematic = true;
		}
		
		EnemySpawner.ES.ShutDown();
		spController.enabled = false;

		player.Pause();
		//Time.timeScale = 0.00f;
	}
	
	
	
	public void OnResume(){
		int i = 0;
		paused = false;
		button_pause.TurnOn();
		if(l_rigidbodies != null){
			foreach(Rigidbody2D R in l_rigidbodies){
				if(!R) continue;
				R.isKinematic = false;
				R.velocity = l_velocities[i++];
			}
		}
		
		EnemySpawner.ES.ReEnable();
		spController.enabled = true;
		player.Resume();
		//Time.timeScale = 1.00f;
	}



	public void GameOver(){
		if(over) return;
		over = true;
		player.Explode();
		EnemySpawner.ES.CancelRestoration();
		button_pause.Disable();
		bombs_buttons.Disable();
		pow_manager.ShutDown();

		Score.S.t_score.Disable();
		EnemySpawner.ES.ShutDown();
		Invoke("AfterOver", 1.50f);
	}



	private void AfterOver(){
		spController.enabled = false;
		curtain.Anim();
		overPop.Enable();
	}
}
