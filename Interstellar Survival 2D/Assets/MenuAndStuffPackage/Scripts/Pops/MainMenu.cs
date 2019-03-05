using UnityEngine;
using System.Collections;

public class MainMenu : PopManager {

	private bool enableAtStart = true;


	private void Start(){
		if(enableAtStart){
			Enable();
		}
	}



	protected override void WhenTurnedOff(){
		enableAtStart = false;
	}
}
