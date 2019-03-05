using UnityEngine;
using System.Collections;

public class ButtonConfigUI : ButtonUI {

	public bool isMusic = true;
	public Sprite offTexture;
	private Sprite onTexture;
	
	
	
	private void Start(){
		if(!MusicAndSoundConfig.started){
			Debug.LogWarning("Make MusicAndSoundConfig be the first thing to run in the script excecution order.");
		}

		onTexture = img.sprite;
		if(isMusic){
			if(MusicAndSoundConfig.music){
				img.sprite = onTexture;
			}
			else{
				img.sprite = offTexture;
			}
		}else {
			if(MusicAndSoundConfig.sound){
				img.sprite = onTexture;
			}
			else{
				img.sprite = offTexture;
			}
		}
	}
	
	
	
	protected override void OnClick(){
		if(isMusic){
			MusicAndSoundConfig.music = !MusicAndSoundConfig.music;
			if(MusicAndSoundConfig.music){
				img.sprite = onTexture;
				PlayerPrefs.SetInt("music", 1);
			}
			else{
				img.sprite = offTexture;
				PlayerPrefs.SetInt("music", 0);
			}
		} else {
			MusicAndSoundConfig.sound = !MusicAndSoundConfig.sound;
			if(MusicAndSoundConfig.sound){
				img.sprite = onTexture;
				PlayerPrefs.SetInt("sound", 1);
			}
			else{
				img.sprite = offTexture;
				PlayerPrefs.SetInt("sound", 0);
			}
		}
	}
}
