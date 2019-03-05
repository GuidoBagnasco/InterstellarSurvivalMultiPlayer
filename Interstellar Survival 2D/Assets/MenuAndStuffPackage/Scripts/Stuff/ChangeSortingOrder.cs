using UnityEngine;
using System.Collections;

public class ChangeSortingOrder : MonoBehaviour {

	public int sortingOrder;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().sortingOrder = sortingOrder;
	}
}
