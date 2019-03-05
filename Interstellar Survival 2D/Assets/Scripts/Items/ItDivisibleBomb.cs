using UnityEngine;
using System.Collections;

public class ItDivisibleBomb : Pows {


	protected override void WhenGrabbed(){
		ItemsCount.IT.AddDivisibleBomb();
	}
	
}
