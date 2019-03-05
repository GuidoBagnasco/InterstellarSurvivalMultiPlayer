using UnityEngine;
using System.Collections;

public class ItShield : Pows {


	protected override void WhenGrabbed(){
		ItemsCount.IT.AddShield();
	}

}
