using UnityEngine;
using System.Collections;

public class ItHealthPack : Item {


	protected override void WhenGrabbed(){
		player.RepairsTaken(9.30f);
	}
	
}
