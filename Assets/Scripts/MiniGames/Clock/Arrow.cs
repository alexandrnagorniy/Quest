using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	public Clock clock;
	void OnMouseDown()
	{
		transform.rotation = Quaternion.Euler (0, 0, transform.eulerAngles.z - 10);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.name == "GameObject")
		clock.Stay ();
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.name == "GameObject")
		clock.Stay ();
	}
}
