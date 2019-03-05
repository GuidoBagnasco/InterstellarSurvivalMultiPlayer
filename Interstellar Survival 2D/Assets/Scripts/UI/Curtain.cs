using UnityEngine;
using System.Collections;

public class Curtain : MonoBehaviour {

	public Animator anim;
	private bool show = false;
	public AudioClip rollUp;
	public AudioClip rollDown;


	public void Anim(){
		show = !show;
		anim.SetBool("Show", show);

		if(show)
			SoundPlayer.Play(rollDown);
		else
			SoundPlayer.Play(rollUp);
	}


	public void StartUp(){
		// The curtain's animator strats off, and the animation that goes up has to be played by default.
		anim.enabled = true;
		anim.Play("CurtainUp");
		SoundPlayer.Play(rollUp);
	}
}
