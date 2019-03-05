using UnityEngine;
using System.Collections;

public class ButtonConfig : ButtonSprite {

	public bool isMusic = true;
	public Sprite offTexture;
	private Sprite onTexture;



	protected override void OnStart(){
		if(!MusicAndSoundConfig.started){
			Debug.LogWarning("Make MusicAndSoundConfig be the first thing to run in the script excecution order.");
		}

		onTexture = r.sprite;
		if(isMusic){
			if(MusicAndSoundConfig.music){
				r.sprite = onTexture;
			}
			else{
				r.sprite = offTexture;
			}
		}else {
			if(MusicAndSoundConfig.sound){
				r.sprite = onTexture;
			}
			else{
				r.sprite = offTexture;
			}
		}
	}



	protected override void OnClick(){
		if(isMusic){
			MusicAndSoundConfig.music = !MusicAndSoundConfig.music;
			if(MusicAndSoundConfig.music){
				r.sprite = onTexture;
				PlayerPrefs.SetInt("music", 1);
			}
			else{
				r.sprite = offTexture;
				PlayerPrefs.SetInt("music", 0);
			}
		} else {
			MusicAndSoundConfig.sound = !MusicAndSoundConfig.sound;
			if(MusicAndSoundConfig.sound){
				r.sprite = onTexture;
				PlayerPrefs.SetInt("sound", 1);
			}
			else{
				r.sprite = offTexture;
				PlayerPrefs.SetInt("sound", 0);
			}
		}
	}
}
