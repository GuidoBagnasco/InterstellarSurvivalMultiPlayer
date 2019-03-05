using UnityEngine;
using System.Collections;

public class PauseButton : ButtonPopUpUI {

	public Controller controller;
	public ButtonOnKey keyToTurnOn;


	protected override void OnClick(){
		if(Controller.over || Controller.paused) return;

		controller.OnPause();

		if(popUpToEnable){
			popUpToEnable.Enable();
			Animation popAnim = popUpToEnable.GetComponent<Animation>();
			if(popAnim) popAnim.Play();
		}
		
		if(popUpToDisable)
			popUpToDisable.TurnOff();

		if(curtain)
			curtain.Anim();

		keyToTurnOn.enabled = true;
	}
}
