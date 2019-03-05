using UnityEngine;
using System.Collections;

public class Installation : MonoBehaviour{
	
	private const string PREF_NAME = "is not first run-asjdihsaiudhisau";
	private const string BASE_PIX_URL = "http://conv.darriensmobile.com/pixel.gif?dt=";
	
	private static int firstRun = 0;
	
	public string gameName;
	public string dToken;
	
	IEnumerator Start()
	{
#if !UNITY_EDITOR
		firstRun = PlayerPrefs.GetInt(PREF_NAME, 0);
		if(firstRun == 0)
		{
			WWW www = new WWW(BASE_PIX_URL + WWW.EscapeURL(dToken) + 
			                  "&udid=" + WWW.EscapeURL(SystemInfo.deviceUniqueIdentifier) + 
			                  "&game=" + WWW.EscapeURL(gameName));
			yield return www;
			if(string.IsNullOrEmpty(www.error))
			{
				firstRun = 1;
				PlayerPrefs.SetInt(PREF_NAME, 1);
				PlayerPrefs.Save();
			}
		}
#endif
		GameObject.Destroy(this);
		yield break;
	}

	/// <summary>
	/// For when You deleted all player prefs.
	/// </summary>
	public static void YouDeletedAllPlayerPrefs()
	{
		PlayerPrefs.SetInt(PREF_NAME, firstRun);
		PlayerPrefs.Save();
	}
}

