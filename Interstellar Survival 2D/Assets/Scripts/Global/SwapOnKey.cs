using UnityEngine;
using System.Collections;

public class SwapOnKey : MonoBehaviour {
	
	public ButtonOnKey buttonToOn;
	public ButtonOnKey buttonToOff;



	public void Click(){
		buttonToOn.enabled = true;
		buttonToOff.enabled = false;
	}
}
