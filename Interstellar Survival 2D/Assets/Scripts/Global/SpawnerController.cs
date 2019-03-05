using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {

	private float timer;
	private float globalTimer = 0.00f;
	private const int NUM_TO_MAKE_HARDER = 3;
	private int countToMakeHarder = 0;

	private float min = 2.30f;
	private float max = 3.40f;
	private const float MIN_DIFF = 0.77f;

	private float c = 1;			// Quantities of enemies spawned pr time



	private void Start(){
		timer = Random.Range(3.60f, 4.10f);
	}


	private void SetTimer(){
		timer = Random.Range(min, max);
	}



	private void EnemiesPerTime(){
		if(globalTimer > 40.0f){
			if(Random.Range(0, 10) > 6)
				c = 2;
			else
				c = 1;
		}
		else{
			c = 1;
		}
	}



	private void Update(){
		if(Controller.paused) return;

		globalTimer += Time.deltaTime;

		if(timer > 0.00f){
			timer -= Time.deltaTime;
		}
		else{
			SetTimer();
			EnemiesPerTime();
			for(short i = 0; i < c; i++){
				EnemySpawner.ES.SpawnShip();
			}
			if(++countToMakeHarder > NUM_TO_MAKE_HARDER){
				countToMakeHarder -= NUM_TO_MAKE_HARDER;
				ShortenTimes();
			}
		}
	}



	private void ShortenTimes(){
		if(min > 0.55f){
			min -= Random.Range(0.19f, 0.35f);
		}
		if(max > 1.15f){
			max -= Random.Range(0.19f, 0.35f);
		}

		if(max - min < MIN_DIFF){
			max = min + MIN_DIFF;
		}
	}
}
