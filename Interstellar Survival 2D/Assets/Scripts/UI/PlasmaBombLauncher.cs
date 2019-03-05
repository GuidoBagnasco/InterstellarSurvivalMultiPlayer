using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class PlasmaBombLauncher : MonoBehaviour, IPointerDownHandler {
	
	public Bomb bomb;
	
	
	
	public void OnPointerDown(PointerEventData data){
		print ("IF1");
		if(Controller.over) return;
		print ("IF2");
		if(ItemsCount.IT.ConsumePlasmaBomb())
			bomb.Enable();
	}
}
