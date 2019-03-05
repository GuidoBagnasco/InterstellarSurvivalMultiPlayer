using UnityEngine;
using System.Collections;

public abstract class Pows : Item {

	public Color c;


	protected override void WhenEnabled(){
		c.a = 1.00f;
		sRenderer.color = c;
	}
}
