using UnityEngine;
using System.Collections;

public class ButtonChangeSceneUI : ButtonUI {
	
	public SceneList.SCENES sceneToChange;
	public float delay = 0;
	public Animator fade;



	protected override void OnClick(){
		Invoke("Change", delay);
		fade.SetBool("Fade", true);
	}


	private void Change(){
		if(sceneToChange == SceneList.SCENES.Exit){
			Application.Quit();
		}
		else{
			Application.LoadLevel((int)sceneToChange);
		}
	}
}
