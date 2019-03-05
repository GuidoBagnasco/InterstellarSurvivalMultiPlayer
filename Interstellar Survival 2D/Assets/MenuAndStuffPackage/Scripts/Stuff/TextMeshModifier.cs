using UnityEngine;
using System.Collections;

public class TextMeshModifier : TextModifier {

	public TextMesh _text;
	public float speedModifier = 1.00f;
	private float speed = 0.00f;


	private void Awake(){
		if(_text == null){
			_text = GetComponent<TextMesh>();
			Debug.LogWarning(transform.name + " didn't have the text assigned.");
		}

		speed = SPEED * speedModifier;
		c = _text.color;
	}
	


	private void Update(){
		switch(state){
			case STATE.Enable:
				if(c.a < 1.00f){
					c.a += Time.deltaTime * speed;
				}
				else{
					c.a = 1.00f;
					enabled = false;
				}
				break;
			case STATE.Disable:
				if(c.a > 0.00f){
					c.a -= Time.deltaTime * speed;
				}
				else{
					c.a = 0.00f;
					enabled = false;
					gameObject.SetActive(false);
				}
				break;
		}

		VaryColour();
	}




	//------------------------PARAMETERS------------------------//
	
	public virtual void ChangeText(string str){
		_text.text = str;
	}
	
	
	public void ChangeFontSize(int size){
		_text.fontSize = size;
	}
	
	
	public void ChangeLineSpacing(float spacing){
		_text.lineSpacing = spacing;
	}
	
	
	public void ChangeFontStyle(int style){
		_text.fontSize = style;
	}


	protected override void VaryColour(){
		_text.color = c;
	}
}
