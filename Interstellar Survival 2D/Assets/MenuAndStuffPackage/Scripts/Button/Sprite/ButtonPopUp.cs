using UnityEngine;
using System.Collections;

public class ButtonPopUp : ButtonSprite {

	public PopManager popUpToEnable;
	public PopManager popUpToDisable;
	
	
	protected override void OnClick(){
		if(popUpToEnable){
			popUpToEnable.Enable();
			Animation popAnim = popUpToEnable.GetComponent<Animation>();
			if(popAnim) popAnim.Play();
		}
		
		if(popUpToDisable)
			popUpToDisable.TurnOff();
	}
}
