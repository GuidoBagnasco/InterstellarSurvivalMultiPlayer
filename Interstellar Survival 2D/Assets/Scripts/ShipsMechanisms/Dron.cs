using UnityEngine;
using System.Collections;

public class Dron : AttackerType {

	public AudioClip clip_apparates;
	public AudioClip clip_dissaparates;
	public ParticleSystem particlesI;
	public ParticleSystem particlesO;
	public GameObject dron;

	private float timerToPreDraw;
	private const float TIMER_TO_DRAW = 0.50f;
	private float timerToDraw;
	private bool preSeen = false;
	private bool seen = false;
	private float timerToVanish;
	
	private float times = 0;

	private Rigidbody2D rBody2D;
	public Item itHealth;


	protected override void OnAwake(){
		enemyType = TYPE.Dron;
		rBody2D = GetComponent<Rigidbody2D>();
		sRenderer = dron.GetComponent<SpriteRenderer>();
	}



	protected override void OnStart(){
		TIME_TO_COOLDOWN = 1.50f;
		SearchBulletsParent();
		base.OnStart();
	}



	protected override void WhenEnabled(){
		SetTimerToDraw();
		times = 1;
		rBody2D.velocity = Vector3.zero;
		preSeen = false;
		seen = false;
	}


	
	protected override void OnUpdate(){
		if(!preSeen){
			if(timerToPreDraw > 0.00f){
				timerToPreDraw -= Time.deltaTime;
				return;
			}
			else{
				PreDraw();
			}
		}

		if(!seen){
			if(timerToDraw > 0.00f){
				timerToDraw -= Time.deltaTime;
				return;
			}
			else{
				Draw();
				return;
			}
		}

		if(timerToVanish > 0.00f){
			timerToVanish -= Time.deltaTime;
			return;
		}
		else{
			Vanish();
		}
	}



	private void PreDraw(){
		preSeen = true;
		if(times++ > 1) Reposition();
		SoundPlayer.Play(clip_apparates);
		particlesI.Emit(30);
		SetTimerToDraw();
	}



	private void Draw(){
		seen = true;
		RotateDron();
		dron.SetActive(true);
		col2D.enabled = true;
		canAttack = true;
		SetTimerToVanish();
		ResetCooldown();
	}



	public override void RotateDron(char d){
		Vector3 diff = player.position - transform.position;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}


	private void Vanish(){
		if(burnt) return;
		preSeen = false;
		seen = false;
		dron.SetActive(false);
		col2D.enabled = false;
		SoundPlayer.Play(clip_dissaparates);
		SetTimerToPreDraw();
		canAttack = false;
		particlesO.Emit(30);
		ResetCooldown();
	}



	private void SetTimerToPreDraw(){
		timerToPreDraw = Random.Range(0.65f, 0.95f);
	}



	private void SetTimerToDraw(){
		timerToDraw = TIMER_TO_DRAW;
	}



	private void SetTimerToVanish(){
		timerToVanish = Random.Range(2.90f, 3.70f);
	}



	private void Reposition(){
		Vector2 point = Random.insideUnitCircle;
		Vector3 pos = new Vector3(point.x, 0.00f, point.y);
		pos -= transform.position;
		pos = pos.normalized * Controller.OFFSET_DRON;
		ValidatePositions(ref pos);
		transform.position = new Vector3(pos.x, 0.00f, pos.z);
		RotateDron();
	}


	public void ValidatePositions(ref Vector3 pos){
		if(pos.x < -Controller.screenLimits.x || pos.x > Controller.screenLimits.x){
			pos.x *= -1;
		}
		if(pos.z < -Controller.screenLimits.y || pos.z > Controller.screenLimits.y){
			pos.z *= -1;
		}
	}


	protected override void SpecialFunction(){
		//if(Random.Range(0, 10) < 2){
			itHealth.Enable();
		//}
	}


	protected override void WhenRestored(){
		transform.rotation = Quaternion.identity;
		rBody2D.velocity = Vector3.zero;
		canAttack = false;
		times = 0;
		ResetCooldown();
	}
}
