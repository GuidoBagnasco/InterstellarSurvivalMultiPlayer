using UnityEngine;
using System.Collections;

public class ShieldLauncher : ButtonUI {

	public Shield shield;



	protected override void OnClick(){
		if(Controller.over || Player.IMMORTAL) return;

		if(ItemsCount.IT.ConsumeShield())
			shield.Activate();
	}
}
