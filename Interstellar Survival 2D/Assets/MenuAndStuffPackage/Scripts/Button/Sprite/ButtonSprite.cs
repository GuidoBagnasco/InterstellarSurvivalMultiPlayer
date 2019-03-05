using UnityEngine;
using System.Collections;

public abstract class ButtonSprite : Button {

	protected SpriteRenderer r;


	private void Start(){
		r = GetComponent<SpriteRenderer>();
		OnStart();
	}


	protected override void VaryColour(){
		r.color = c;
	}
}
