using UnityEngine;
using System.Collections;

public class ReturnToMenuButton : ButtonChangeSceneUI {

	public Controller controller;



	protected override void OnClick(){
		base.OnClick();

		Controller.over = true;
		controller.OnResume();
	}
}
