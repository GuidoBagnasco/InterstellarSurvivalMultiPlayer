using UnityEngine;
using System.Collections;

public class ButtonMoreGames : ButtonSprite {

	protected override void OnClick(){
		Application.OpenURL("https://play.google.com/store/apps/developer?id=d%27factory");
	}
}