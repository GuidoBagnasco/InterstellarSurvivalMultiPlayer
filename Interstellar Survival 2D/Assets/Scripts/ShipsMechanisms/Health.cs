using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	private const float MIN = 0.00f;
	private const float MAX = 100.00f;
	private float percentage = MAX;

	public UnityEngine.UI.Image bar;
	public Controller controller;




	public void DamageTaken(float damage){
		percentage -= damage;
		CheckPercentage();
		ResizeBar();
	}


	public void RepairsTaken(float repairs){
		percentage += repairs;
		CheckPercentage();
		ResizeBar();
	}



	private void CheckPercentage(){
		if(percentage > MAX){
			percentage = MAX;
			return;
		}
		if(percentage < MIN){
			percentage = MIN;

			controller.GameOver();
			return;
		}
	}



	private void ResizeBar(){
		bar.fillAmount = percentage / MAX;
	}
}
