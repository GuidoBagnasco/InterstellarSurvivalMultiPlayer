using UnityEngine;
using System.Collections;

public class RateUsPopUp : PopManager {

	private const int TIMES_UNTIL_RATE = 3;
	public PopManager popUpToDisable;

	public bool debugMode = true;
	public bool isSubscription = false;


	// TODO: See if this'll have to work on IOS.

	private void Start(){
#if !UNITY_ANDROID
		return;
#endif

		//This script shouldn't work if the app was downloaded from renxo or stuff.
		if(isSubscription) return;

#if UNITY_EDITOR
		// This resets the key if never or yes has been pressed before. The boolean is to choose to run this or not.
		// And the conditional is set to prevent this from work when it's not running in the editor.
		if(debugMode && PlayerPrefs.GetInt("menuTimes", 0) == -1){
			PlayerPrefs.SetInt("menuTimes", 0);
		}
#endif

		int passedTruMenu = PlayerPrefs.GetInt("menuTimes", 0);

		if(passedTruMenu < 0) return;

		if(passedTruMenu >= TIMES_UNTIL_RATE){
			passedTruMenu = 0;
			PlayerPrefs.SetInt("menuTimes", passedTruMenu);
			popUpToDisable.TurnOff();
			Enable();
		}
		else{
			PlayerPrefs.SetInt("menuTimes", ++passedTruMenu);
		}
	}
}
