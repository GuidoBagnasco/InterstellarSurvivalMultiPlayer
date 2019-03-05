using UnityEngine;
using System.Collections;

public class ItPlasmaBomb : Pows {


	protected override void WhenGrabbed(){
		ItemsCount.IT.AddPlasmaBomb();
	}
	
}
