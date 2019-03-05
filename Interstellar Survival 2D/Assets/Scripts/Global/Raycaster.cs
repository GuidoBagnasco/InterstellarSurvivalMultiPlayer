using UnityEngine;
using System.Collections;

public class Raycaster : Raycaster2D {

	public static int shipNavID = -1;



	public static void ResetNavID(){
		shipNavID = -1;
	}
	


	protected override void Function(Collider2D col, int id){
		if(col.tag == "Clickable"){						// Buttons and stuff
			col.transform.GetComponent<Button>().Click();
		}
		else if(col.tag.Equals("Expander")){			// Divisible bomb
			col.transform.GetComponent<Divider>().Divide();
		}
	}
}
