using UnityEngine;
using System.Collections;

public abstract class ObjectManagment : MonoBehaviour {

	private const float SPEED = 1.35F;
	public float speedModifier = 1.00f;

	private enum FUNCTION{
		Sleep = 0,
		Enable = 1,
		Disable = 2
	}

	private FUNCTION function = FUNCTION.Sleep;

	protected Color c = Color.white;
	public Collider2D col2D;
	



	private void Start(){
		OnStart();
	}


	protected virtual void OnStart(){	}


	// Progressive enable
	public void Enable(){
		function = FUNCTION.Enable;
		WhenEnabled();
		enabled = true;
	}


	protected virtual void WhenEnabled(){
		if(col2D) col2D.enabled = true;
	}


	// Progressive disable
	public void Disable(){
		function = FUNCTION.Disable;
		WhenDisabled();
		enabled = true;
	}


	protected virtual void WhenDisabled(){
		if(col2D) col2D.enabled = false;
	}

	
	private void Update(){
		switch(function){
			case FUNCTION.Enable:
				if(c.a < 1.00f){
					c.a += Time.deltaTime * SPEED * speedModifier;
				}
				else{
					c.a = 1.00f;
					function = FUNCTION.Sleep;
				}
				break;

		case FUNCTION.Disable:
			if(c.a > 0.00f){
					c.a -= Time.deltaTime * SPEED * speedModifier;
				}
			else{
					c.a = 0.00f;
					function = FUNCTION.Sleep;
					Deactivate();
				}
				break;

			default:
				enabled = false;
				break;
		}
		VaryColour();
	}


	// Snappy enable
	public void TurnOn(){
		Activate();
		c.a = 1.00f;
		if(col2D) col2D.enabled = true;
		function = FUNCTION.Sleep;
		VaryColour();
	}


	// Snappy disable
	public void TurnOff(){
		c.a = 0.00f;
		if(col2D) col2D.enabled = false;
		function = FUNCTION.Sleep;
		VaryColour();
		Deactivate();
	}


	protected virtual void Activate(){
		gameObject.SetActive(true);
	}


	protected virtual void Deactivate(){
		gameObject.SetActive(false);
	}

	
	protected abstract void VaryColour();

}
