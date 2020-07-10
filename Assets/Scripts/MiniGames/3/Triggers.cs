using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour {
	public bool stay;
	public float timer;
	private float cd = 2f;
	public DomcratController controller;
	public bool added;
	// Use this for initialization
	void Start () {
		
	}

	// -3 8 -9
	
	// Update is called once per frame
	void Update () 
	{
		if (stay) {
			if (timer > 0)
				timer -= Time.deltaTime;
			else {
				if(!added)
				controller.Add ();
				added = true;
			}
		}	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Target") {
			if (!added) {
				stay = true;
				timer = cd;
			}
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		stay = false;
	}
}
