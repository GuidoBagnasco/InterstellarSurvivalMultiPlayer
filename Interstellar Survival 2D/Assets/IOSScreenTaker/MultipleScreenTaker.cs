using UnityEngine;
using System.Collections;
#pragma warning disable 0162

public class MultipleScreenTaker : MonoBehaviour {

	public KeyCode keyToPress = KeyCode.Space;
	public string path = "C:\\";
	//public Camera[] cams;
	public Vector2[] resolutions;

	public int screenNumber = 0;

	static bool started = false;

	public Canvas canvas;
	public Camera[] v_cams;

	public bool singleCamera = true;


	void Start(){
		if(started){
			Destroy(gameObject);
			return;
		}

#if !UNITY_EDITOR
		enabled = false;
		return;
#endif

		if(v_cams == null || v_cams.Length == 0)
			SearchCameras();

		if(!canvas)
			SearchCanvas();

		started = true;
		DontDestroyOnLoad(gameObject);
	}


	void Update () {
		if(Input.GetKeyDown(keyToPress)){
			StartCoroutine(TakeScreens());
		}
	}


	void SearchCameras(){
		v_cams = GameObject.FindObjectsOfType<Camera>() as Camera[];
	}


	void SearchCanvas(){
		canvas = GameObject.FindObjectOfType<Canvas>() as Canvas;
	}


	IEnumerator TakeScreens(){
		foreach(Vector2 v in resolutions){
			RenderTexture re = new RenderTexture((int)v.x,(int)v.y,24);
			re.Create();
			if(canvas){
				canvas.renderMode = RenderMode.ScreenSpaceCamera;
				canvas.worldCamera = v_cams[0];
				canvas.planeDistance = 1;
			}
			//yield return new WaitForSeconds(0.1f);
			foreach(Camera cam in v_cams){
				cam.targetTexture = re;
				cam.Render();
			}
			RenderTexture.active = re;
			Texture2D t = new Texture2D((int)v.x,(int)v.y,TextureFormat.RGB24,false);
			t.ReadPixels(new Rect(0,0,t.width,t.height),0,0);
			t.Apply();
			byte[] bytes;
			bytes = t.EncodeToPNG();
			System.IO.File.WriteAllBytes( path + Application.productName + " (" + t.width + "," + t.height + ") " + screenNumber + ".jpg", bytes );
		}
		foreach(Camera cam in v_cams){
			cam.targetTexture = null;
		}
		screenNumber ++;
		yield return new WaitForEndOfFrame();
	}


	void OnLevelWasLoaded(int level){
		if(singleCamera)
			SearchCameras();
		SearchCanvas();
	}

	/*void TakeScreen(Camera c){
		canvas.worldCamera = c;
		canvas.planeDistance = 0.1f;
		RenderTexture.active = c.targetTexture;
		Texture2D t = new Texture2D(c.targetTexture.width,c.targetTexture.height);
		t.ReadPixels(new Rect(0,0,t.width,t.height),0,0);
		t.Apply();
		byte[] bytes;
		bytes = t.EncodeToPNG();
		System.IO.File.WriteAllBytes( path + Application.productName + " (" + t.width + "," + t.height + ") " + screenNumber + ".png", bytes );
	}*/
}
