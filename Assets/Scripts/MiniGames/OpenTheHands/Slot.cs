using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {
	public Keys keyScript;
	void OnTriggerEnter2D(Collider2D coll)
	{
		keyScript.stays[keyScript.i] = true;
		coll.GetComponent<SpriteRenderer>().color = Color.green;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		coll.GetComponent<SpriteRenderer>().color = Color.white;
		keyScript.stays[keyScript.i] = false;	
	}

}
