using UnityEngine;
using System.Collections;

public class ButtonPopUpUI : ButtonUI {

	public PopManager popUpToEnable;
	public PopManager popUpToDisable;
	public Curtain curtain;


	protected override void OnClick(){
		if(popUpToEnable){
			popUpToEnable.Enable();
			Animation popAnim = popUpToEnable.GetComponent<Animation>();
			if(popAnim) popAnim.Play();
		}

		if(curtain)
			curtain.Anim();

		if(popUpToDisable)
			popUpToDisable.TurnOff();
	}
}
