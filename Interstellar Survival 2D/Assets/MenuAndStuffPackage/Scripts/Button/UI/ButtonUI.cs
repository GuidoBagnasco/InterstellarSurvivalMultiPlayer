using UnityEngine;
using System.Collections;

public abstract class ButtonUI : Button {

	protected UnityEngine.UI.Image img;
	protected UnityEngine.UI.Button	button;


	private void Awake(){
		img = GetComponent<UnityEngine.UI.Image>();
		button = GetComponent<UnityEngine.UI.Button>();
	}


	protected override void WhenEnabled(){
		button.interactable = true;
	}
	
	
	
	protected override void WhenDisabled(){
		if(button)
			button.interactable = false;
		else
			Debug.Log(gameObject.name + " doesn't have the Button component.");
	}



	protected override void VaryColour(){
		if(img) img.color = c;
	}
}
