using UnityEngine;
using System.Collections;

public class ButtonOnKey : MonoBehaviour {

	public Button[] buttons;
	public KeyCode key;




	private void Update(){
		if(Input.GetKeyDown(key)){
			for(byte i = 0; i < buttons.Length; i++){
				buttons[i].Click();
			}

			// See if this should run always or on certain cases
			enabled = false;
		}
	}
}
