using UnityEngine;
using System.Collections;

public class ItemsCount : MonoBehaviour {

	private int PlasmaBombs = 0;
	private int DivisibleBombs = 0;
	private int Shields = 0;
	private int Freezers = 0;

	public static ItemsCount IT;

	public UnityEngine.UI.Text t_plasma;
	public UnityEngine.UI.Text t_divisible;
	public UnityEngine.UI.Text t_shield;
	public UnityEngine.UI.Text t_freezer;



	private void Start(){
		IT = this;

		// When the game was under tests, the initial quantities of the bomb started at 100.
		UpdateText(t_plasma, PlasmaBombs);
		UpdateText(t_divisible, DivisibleBombs);
		UpdateText(t_shield, Shields);
		UpdateText(t_freezer, Freezers);
	}


	private void OnDestroy(){
		IT = null;
	}


	public void AddPlasmaBomb(){
		PlasmaBombs++;
		UpdateText(t_plasma, PlasmaBombs);
	}

	public bool ConsumePlasmaBomb(){
		if(PlasmaBombs > 0){
			PlasmaBombs--;
			UpdateText(t_plasma, PlasmaBombs);
			return true;
		}
		return false;
	}



	public void AddDivisibleBomb(){
		DivisibleBombs++;
		UpdateText(t_divisible, DivisibleBombs);
	}
	
	public bool ConsumeDivisibleBomb(){
		if(DivisibleBombs > 0){
			DivisibleBombs--;
			UpdateText(t_divisible, DivisibleBombs);
			return true;
		}
		return false;
	}



	public void AddShield(){
		Shields++;
		UpdateText(t_shield, Shields);
	}
	
	public bool ConsumeShield(){
		if(Shields > 0){
			Shields--;
			UpdateText(t_shield, Shields);
			return true;
		}
		return false;
	}



	public void AddLightning(){
		Freezers++;
		UpdateText(t_freezer, Freezers);
	}
	
	public bool ConsumeThunder(){
		if(Freezers > 0){
			Freezers--;
			UpdateText(t_freezer, Freezers);
			return true;
		}
		return false;
	}


	private void UpdateText(UnityEngine.UI.Text t, int val){
		t.text = val.ToString();
	}
}
