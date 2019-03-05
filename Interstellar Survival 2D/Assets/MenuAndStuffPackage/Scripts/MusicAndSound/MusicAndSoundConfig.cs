using UnityEngine;
using System.Collections;

public class MusicAndSoundConfig : MonoBehaviour {

	public static bool started;
	
	public static bool music = true;
	public static bool sound = true;
	private AudioSource source;


	private void Start(){
		if(started)
			Destroy(gameObject);
		else{
			started = true;
			source = GetComponent<AudioSource>();
			DontDestroyOnLoad(gameObject);
			if(PlayerPrefs.GetInt("music", 1) == 1){
				music = true;
			}
			else{
				music = false;
			}

			if(PlayerPrefs.GetInt("sound", 1) == 1){
				sound = true;
			}
			else{
				sound = false;
			}
		}
	}


	private void Update(){
		if(music){
			if(!source.isPlaying)
				source.Play();
		}
		else{
			if(source.isPlaying)
				source.Stop();
		}
	}
}
