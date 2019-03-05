using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static Score S;
	private float score = 0;

	public UITextModifier t_score;
	public PowsManager powsManager;

	private int enemiesDown = 0;


	
	private void Awake(){
		S = this;
	}
	


	public void AddScore(float f){
		score += f;
		t_score.ChangeText(((int)score).ToString("000000"));
	}


	public void EnemyDown(){
		enemiesDown++;
		powsManager.EnemyDown();
	}


	public void GetInfo(ref float score, ref int enemies){
		score = this.score;
		enemies = enemiesDown;
	}


	private void OnDestroy(){
		S = null;
	}
}
