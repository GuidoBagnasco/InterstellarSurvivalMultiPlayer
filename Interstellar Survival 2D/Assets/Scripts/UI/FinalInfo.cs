using UnityEngine;
using System.Collections;

public class FinalInfo : UITextModifier {

	private float score = 0.00f;
	private int qDown = 0;
	private float hiScore = 0;
	//private int maxqDown = 0;
	



	private void Start(){
		Score.S.GetInfo(ref score, ref qDown);
		Check();

		ChangeText(((int)score).ToString("000000") + "\n" + qDown.ToString("##0") + "\n" + ((int)hiScore).ToString("000000"));
	}



	public void Check(){
		hiScore = PlayerPrefs.GetFloat("Hi-Score", 0);
		//maxqDown = PlayerPrefs.GetInt("ShipsDown", 0);

		if(PlayerPrefs.HasKey("ShipsDown"))
		   PlayerPrefs.DeleteKey("ShipsDown");

		if(score > hiScore){
			hiScore = score;
			PlayerPrefs.SetFloat("Hi-Score", hiScore);
		}
		/*
		if(qDown > maxqDown){
			maxqDown = qDown;
			PlayerPrefs.SetInt("ShipsDown", maxqDown);
		}
		*/
	}
}
