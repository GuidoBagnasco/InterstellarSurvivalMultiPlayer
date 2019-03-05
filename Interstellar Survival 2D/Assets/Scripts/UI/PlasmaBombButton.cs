using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class PlasmaBombButton : ButtonUI {



	protected override void OnClick(){
		if(Controller.over || Player.USE_PLASMA_BOMB || Player.USE_DIVISIBLE_BOMB) return;

		if(ItemsCount.IT.ConsumePlasmaBomb()){
			Player.USE_PLASMA_BOMB = true;
		}
	}

	/*
	public void OnPointerDown(PointerEventData data){
		if(ItemsCount.IT.ConsumePlasmaBomb()){
			Raycaster.plasmaID = data.pointerId;
			bomb.Enable();
		}
	}
	*/
}
