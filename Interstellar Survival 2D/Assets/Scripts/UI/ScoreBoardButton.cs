using UnityEngine;
using System.Collections;

public class ScoreBoardButton : ButtonUI {

	public Controller controller;


	protected override void OnClick(){
		Invoke("Vanish", 0.90f);
		controller.StartGame();
	}



	private void Vanish(){
		transform.parent.gameObject.SetActive(false);
	}
}
