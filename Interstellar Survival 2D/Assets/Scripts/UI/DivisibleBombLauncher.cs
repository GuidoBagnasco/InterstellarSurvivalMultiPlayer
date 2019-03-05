using UnityEngine;
using System.Collections;

public class DivisibleBombLauncher : ButtonUI {	



	protected override void OnClick(){
		if(Controller.over || Player.USE_DIVISIBLE_BOMB || Player.USE_PLASMA_BOMB) return;

		if(ItemsCount.IT.ConsumeDivisibleBomb())
			Player.USE_DIVISIBLE_BOMB = true;
	}
}
