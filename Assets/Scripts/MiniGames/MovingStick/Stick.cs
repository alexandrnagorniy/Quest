using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour {
	public StickManager manager;
	private bool stay;
	private bool massaged;
	public float min, max, spd;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		if(!massaged)
			transform.Translate (Vector2.right * spd * Time.deltaTime);
		if (transform.localPosition.x < min || transform.localPosition.x > max)
			spd *= -1;
			
	}

	void OnMouseDown()
	{
		Debug.Log ("Click");
		if (stay && !massaged) 
		{
			manager.Stay (1);
			massaged = true;
		}

		if (!stay && massaged) 
		{
			manager.Stay (-1);
			massaged = false;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Untagged")
			stay = true;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Untagged")
			stay = false;
	}
}
