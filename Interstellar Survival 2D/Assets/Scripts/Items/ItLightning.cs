using UnityEngine;
using System.Collections;

public class ItLightning : Pows {


	protected override void WhenGrabbed(){
		ItemsCount.IT.AddLightning();
	}
	
}
