using UnityEngine;
using System.Collections;

public class AmbienceSoundPlayer : MonoBehaviour {

	private AudioSource source;
	private static bool started = false;
	
	private int previousScene;
	
	
	
	private void Awake(){
		if(started){
			Destroy(gameObject);
		}
		else{
			started = true;
			previousScene = Application.loadedLevel;
			source = GetComponent<AudioSource>();
			DontDestroyOnLoad(gameObject);
		}
	}
	
	
	
	private void Update(){
		if(Application.loadedLevel == (int)SceneList.SCENES.Game)
			PlayAudio();
	}
	
	
	
	private void OnLevelWasLoaded(int level){
		if(level == (int)SceneList.SCENES.Menu){
			source.Stop();
		}
		else if(previousScene != level){
			PlayAudio(true);
			previousScene = level;
		}
	}
	
	
	
	private void PlayAudio(bool forced = false){
		if(MusicAndSoundConfig.music){
			if(forced || !source.isPlaying){
				source.Play();
			}
		}
		else{
			if(source.isPlaying){
				source.Stop();
			}
		}
	}
}

