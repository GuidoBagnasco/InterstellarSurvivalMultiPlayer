using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	
	public PauseButton button_pause;
	private bool recentlyEnabled = false;


	//--------------------------------------------------------------------------------//

	// Done cause sometimes the pause triggers by itself when the game is tested.
	private void OnEnable(){
		recentlyEnabled = true;
	}


	private void Update(){
		recentlyEnabled = false;
		enabled = false;
	}
	//--------------------------------------------------------------------------------//


	public void OnApplicationPause(bool pauseStatus){
		if(pauseStatus && !recentlyEnabled){
			button_pause.Click();
		}
	}

}
