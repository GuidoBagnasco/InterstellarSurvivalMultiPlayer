using UnityEngine;
using System.Collections;

public class ItemsDeactivation : MonoBehaviour {

	public Item[] l_items;



	private void Awake(){
		l_items = GetComponents<Item>();
	}
	


	public void Deactivate(){
		foreach(Item item in l_items){
			item.Disable();
		}
	}
}
