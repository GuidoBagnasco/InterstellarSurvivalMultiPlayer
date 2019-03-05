using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopManager : MonoBehaviour {
	
	public List<ObjectManagment> l_objs;	// Pop up and images
	public List<Button> l_buttons;			// Buttons
	public List<TextModifier> l_texts;		// Texts

	public float delay = 0.00f;

	

	public void Enabling(){
		foreach(ObjectManagment bf in l_objs){
			bf.gameObject.SetActive(true);
			bf.Enable();
		}
		
		foreach(Button b in l_buttons){
			b.gameObject.SetActive(true);
			b.Enable();
		}
		
		foreach(TextModifier t in l_texts){
			t.gameObject.SetActive(true);
			t.Enable();
		}
	}


	public void Enable(){
		Invoke("Enabling", delay);
		// This can be used if the progressive appearance of objects is not wanted.
		// The 3 loops form above DON'T have to run if this other loop runs.
		/*
		for(short i = 0; i < transform.childCount; i++){
			transform.GetChild(i).gameObject.SetActive(true);
		}
		*/

		WhenEnabled();
	}


	protected virtual void WhenEnabled(){	}



	public void Disable(){
		WhenDisabled();

		foreach(ObjectManagment bf in l_objs){
			bf.Disable();
		}

		foreach(Button b in l_buttons){
			b.Disable();
		}

		foreach(TextModifier t in l_texts){
			t.Disable();
		}


		// This can be used if the progressive appearance of objects is not wanted.
		// The 3 loops form above DON'T have to run if this other loop runs.
		/*
		for(short i = 0; i < transform.childCount; i++){
			transform.GetChild(i).gameObject.SetActive(false);
		}
		*/
	}


	protected virtual void WhenDisabled(){	}




	public void TurnOn(){
		WhenTurnedOn();
		
		foreach(ObjectManagment bf in l_objs){
			bf.TurnOn();
		}
		
		foreach(Button b in l_buttons){
			b.TurnOn();
		}
		
		foreach(TextModifier t in l_texts){
			t.TurnOn();
		}
	}
	
	
	protected virtual void WhenTurnedOn(){		}




	public void TurnOff(){
		WhenTurnedOff();

		foreach(ObjectManagment bf in l_objs){
			bf.TurnOff();
		}
		
		foreach(Button b in l_buttons){
			b.TurnOff();
		}
		
		foreach(TextModifier t in l_texts){
			t.TurnOff();
		}
	}


	protected virtual void WhenTurnedOff(){		}
}
