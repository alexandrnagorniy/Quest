using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TahoButton : MonoBehaviour {
	public Transform arrowTransform;

	void OnMouseDown()
	{
		arrowTransform.Rotate (0, 0, -10);	
	}
}
