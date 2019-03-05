using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShipsRotation : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {

	public Player player;
	public Cursor cursor;
	private int fingers = 0;
	private int fingerId = -1;



	public void OnPointerDown(PointerEventData data){
		if(fingerId != -1)
			return;

		Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		if(col != null && col.tag.Equals("Expander")) return;
		fingers++;

		fingerId = data.pointerId;

		MoveShip(data.position);
		cursor.Disapparate();
	}



	public void OnPointerUp(PointerEventData data){
		if(fingerId != data.pointerId)
			return;

		fingerId = -1;

		Vector3 point = Camera.main.ScreenToWorldPoint(data.position);
		point.z = player.transform.position.z;

		//if(player.posToMove != point) return;

		if(fingers > 0){
			fingers--;
			cursor.Apparate(data.position);
		}
	}



	public void OnDrag(PointerEventData data){
		if(fingerId != data.pointerId)
			return;

		MoveShip(data.position);
	}
	


	private void MoveShip(Vector3 point){
		if(fingers <= 0) return;
		point = Camera.main.ScreenToWorldPoint(point);
		point.z = player.transform.position.z;
		player.MoveToPos(point);
	}
}
