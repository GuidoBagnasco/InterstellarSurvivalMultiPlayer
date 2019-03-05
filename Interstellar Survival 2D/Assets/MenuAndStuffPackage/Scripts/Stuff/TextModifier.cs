using UnityEngine;
using System.Collections;

public abstract class TextModifier : MonoBehaviour {

	// Used to unify TexMeshes and UITexts

	protected const float SPEED = 1.60F;
	protected enum STATE{
		Enable = 0,
		Disable = 1
	}
	
	protected STATE state;
	protected Color c;
	


	// Progressive enable
	public void Enable(){
		state = STATE.Enable;
		enabled = true;
	}
	

	// Progressive disable
	public void Disable(){
		state = STATE.Disable;
		enabled = true;
	}



	// Snappy enable
	public void TurnOn(){
		gameObject.SetActive(true);
		c.a = 1.00f;
		enabled = true;
		
		VaryColour();
	}



	// Snappy disable
	public void TurnOff(){
		c.a = 0.00f;
		enabled = false;
		gameObject.SetActive(false);

		VaryColour();
	}


	protected abstract void VaryColour();

}
