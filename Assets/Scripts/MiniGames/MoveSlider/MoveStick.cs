using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStick : MonoBehaviour {
	public MoveStickManager manager;
	public float min, max;
	float x;
	// Use this for initialization
	void Start () {
		min = transform.position.x - 2;
		max = transform.position.x + 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{

	}

	void OnMouseDrag()
	{
		
		if (transform.position.x < min)
			x = min + 0.1f;
		else if (transform.position.x > max)
			x = max - 0.1f;
		else
			x = transform.position.x + Input.GetAxis("Mouse X") / 3;
		transform.position = new Vector2 (x, transform.position.y);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "GameController") 
		{
			manager.Entered ();
			GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
