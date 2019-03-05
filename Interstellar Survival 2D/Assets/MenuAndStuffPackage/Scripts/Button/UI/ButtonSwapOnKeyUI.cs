using UnityEngine;
using System.Collections;

public class ButtonSwapOnKeyUI : ButtonPopUpUI {

	public ButtonOnKey keyToTurnOn;

	
	protected override void OnClick(){
		base.OnClick();
		keyToTurnOn.enabled = true;
	}
}
