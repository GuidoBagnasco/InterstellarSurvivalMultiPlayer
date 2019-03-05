using UnityEngine;
using System.Collections;

public abstract class Button : ObjectManagment {

	public AudioClip clip;



	public void Click(){
		OnClick();

		if(clip){
			SoundPlayer.Play(clip);
		}
	}



	protected abstract void OnClick();
}
