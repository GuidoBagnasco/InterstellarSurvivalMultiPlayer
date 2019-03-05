using UnityEngine;
using System.Collections;

public class ResumeButton : ButtonPopUpUI {

	public Controller controller;
	public ButtonOnKey keyToTurnOn;



	protected override void OnClick(){
		base.OnClick();
		controller.OnResume();
		keyToTurnOn.enabled = true;
	}

}
