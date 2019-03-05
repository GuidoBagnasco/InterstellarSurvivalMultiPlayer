using UnityEngine;
using System.Collections;

public class SingleScreenshotsTaker : MonoBehaviour {

	private int photoNumber = 0;
	private static bool Started = false;


	private void Start(){
		if(!Started){
			DontDestroyOnLoad(gameObject);
			Started = true;
			photoNumber = PlayerPrefs.GetInt("PhotoNumber", 1);
		}
		else{
			Destroy(gameObject);
		}
#if !UNITY_EDITOR
		enabled = false;
#endif

	}
	

	private void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			photoNumber++;
			Application.CaptureScreenshot("/Users/dfactory/Desktop/Games/Interstellar Survival 2D/Technical Images/Screenshots/IOS/Screenshot_"+photoNumber+".png");
			PlayerPrefs.SetInt("PhotoNumber", photoNumber);
		}
	}
}
