using UnityEngine;
using System.Collections;

public class ObjectUI : ObjectManagment {

	// This script is used for objects which alpha may change.

	private UnityEngine.UI.Image img;
	
	
	
	private void Awake(){
		img = GetComponent<UnityEngine.UI.Image>();
	}
	
	
	
	protected override void VaryColour(){
		if(img) img.color = c;
	}

}
