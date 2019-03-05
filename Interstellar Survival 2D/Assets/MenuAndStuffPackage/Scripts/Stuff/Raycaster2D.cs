using UnityEngine;
using System.Collections;

public class Raycaster2D : MonoBehaviour {

	public LayerMask mask;


	private void Start(){
		if(mask.value == 0){			// Nothing
			mask.value = -1;			// Everything
		}
	}


	private void Update(){
		if(Input.touches.Length == 0){						// Single
			if(Input.GetMouseButtonDown(0)){
				Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), mask);
				
				if(col != null){
					Function(col);
				}
			}
		}
		else{												// Multi
			for(short i = 0; i < Input.touchCount; i++){
				if(Input.touches[i].phase == TouchPhase.Began){
					Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.touches[i].position), mask);
					
					if(col != null){
						Function(col, Input.touches[i].fingerId);
					}
				}
			}
		}
	}



	protected virtual void Function(Collider2D col, int id = -1){
		if(col.tag == "Clickable"){						// Buttons and stuff
			col.transform.GetComponent<Button>().Click();
		}
	}
}
