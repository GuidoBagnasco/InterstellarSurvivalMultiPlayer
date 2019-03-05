using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
	
	private const int DRONS_Q = 4;
	private const int SHIPS_AQ = 13;
	private const int SHIPS_BQ = 7;
	private const int SHIPS_CQ = 2;

	public static EnemySpawner ES;
	private const float RADIUS = 5.00F;

	public Transform player;
	public GameObject shipPrefab_A;
	public GameObject shipPrefab_B;
	public GameObject shipPrefab_C;
	public GameObject dronPrefab;
	private List<Enemy> l_stocked = new List<Enemy>();
	public List<Enemy> l_used = new List<Enemy>();




	private void Awake(){
		ES = this;

		for(short i = 0; i < SHIPS_AQ; i++){
			GameObject go = Instantiate(shipPrefab_A) as GameObject;
			go.transform.SetParent(transform);
			Enemy e = go.GetComponent<Enemy>();
			e.player = player;
			l_stocked.Add(e);
		}


		for(short i = 0; i < SHIPS_BQ; i++){
			GameObject go = Instantiate(shipPrefab_B) as GameObject;
			go.transform.SetParent(transform);
			Enemy e = go.GetComponent<Enemy>();
			e.player = player;
			l_stocked.Add(e);
		}


		for(short i = 0; i < SHIPS_CQ; i++){
			GameObject go = Instantiate(shipPrefab_C) as GameObject;
			go.transform.SetParent(transform);
			Enemy e = go.GetComponent<Enemy>();
			e.player = player;
			l_stocked.Add(e);
		}


		for(short i = 0; i < DRONS_Q; i++){
			GameObject go = Instantiate(dronPrefab) as GameObject;
			go.transform.SetParent(transform);
			Enemy e = go.GetComponent<Enemy>();
			e.player = player;
			l_stocked.Add(e);
		}
	}

	
	
	public void SpawnShip(){
		Enemy enemy = null;
		if(l_stocked.Count > 0){
			int n = Random.Range(0, l_stocked.Count);
			enemy = l_stocked[n];
			l_stocked.RemoveAt(n);
			l_used.Add(enemy);
		}
		else{
			return;
		}

		Vector2 point = Random.insideUnitCircle;
		Vector3 pos = new Vector3(point.x, point.y, 0.00f);
		pos -= transform.position;

		switch(enemy.GetEnemyType()){
			case Enemy.TYPE.Ship:
				pos = pos.normalized * Controller.OFFSET_SHIP;
				break;
			case Enemy.TYPE.Dron:
				pos = pos.normalized * Controller.OFFSET_DRON;
				(enemy as Dron).ValidatePositions(ref pos);
				break;
		}
		
		enemy.transform.position = new Vector3(pos.x, pos.y, 0.00f);
		enemy.enabled = true;
	}
	
	
	
	public void StoreShip(Enemy enemy){
		enemy.transform.position = (Vector3.right + Vector3.up) * 300f;
		l_used.Remove(enemy);
		l_stocked.Add(enemy);
	}
	


	public void ReEnable(){
		for(int i = 0; i < l_used.Count; i++){
			l_used[i].enabled = true;
		}
	}


	public void ShutDown(){
		foreach(Enemy e in l_used){
			e.enabled = false;
			e.Pause();
			if(e.GetEnemyType() == Enemy.TYPE.Ship) e.ShutDown();
		}
	}
	

	public void CancelRestoration(){
		foreach(Enemy e in l_used){
			e.CancelInvoke("Restore");
			e.Resume();
		}
	}


	public List<Enemy> ActiveEnemies(){
		return l_used;
	}


	private void OnDestroy(){
		ES = null;
	}
}
