using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	static bool started = false;
	static AudioSource source;

	private static bool warning = false;


	private void Awake(){
		if(started){
			Destroy(gameObject);
		}
		else{
			started = true;
			source = GetComponent<AudioSource>();
			DontDestroyOnLoad(gameObject);
		}
	}


	public static void Play(AudioClip clip){
		if(started){
			if(MusicAndSoundConfig.sound) source.PlayOneShot(clip);
		}
		else if(!warning){
			Debug.LogWarning("There's no SoundPlayer in the scene.");
			warning = true;
		}
	}
}
