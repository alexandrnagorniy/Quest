using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelMoveX : MonoBehaviour {
	public float speed;
	public float minX, maxX;
	public float x;

	void Start () {
		
	}

	void Update () {
		if (transform.localPosition.x < minX)
			x = minX;
		else if (transform.localPosition.x > maxX)
			x = maxX;
		else {
			x = Input.acceleration.x * 3;
			//x += Input.GetAxis ("Horizontal");
		}
		transform.localPosition = new Vector2 (x, transform.localPosition.y);
	}
}
