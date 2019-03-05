using UnityEngine;
using System.Collections;

public class ObjectSprite : ObjectManagment {

	// This script is used for objects which alpha may change.
	protected SpriteRenderer sRenderer;

	private void Awake(){
		sRenderer = GetComponent<SpriteRenderer>();
	}


	protected override void VaryColour(){
		sRenderer.color = c;
	}

}
