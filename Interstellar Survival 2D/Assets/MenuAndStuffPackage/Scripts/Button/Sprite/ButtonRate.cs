using UnityEngine;
using System.Collections;

public class ButtonRate : ButtonSprite {

	public string url;
	public bool never;
	public PopManager popToEnable;
	public PopManager popToDisable;
	
	
	protected override void OnClick(){
		if(url != ""){
			Application.OpenURL(url);
			PlayerPrefs.SetInt("menuTimes", -1);
		}
		if(never){
			PlayerPrefs.SetInt("menuTimes", -1);
		}
		
		popToEnable.Enable();
		popToDisable.TurnOff();
	}
}
