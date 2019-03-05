using UnityEngine;
using System.Collections;

public class ButtonSwapOnKey : ButtonPopUp {

	public ButtonOnKey keyToTurnOn;
	
	
	protected override void OnClick(){
		base.OnClick();
		keyToTurnOn.enabled = true;
	}
}
