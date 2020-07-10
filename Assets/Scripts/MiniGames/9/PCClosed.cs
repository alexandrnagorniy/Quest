using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCClosed : MonoBehaviour {
	PCManager manager;
	public int picture;
	// Use this for initialization
	void Start () {
		manager = transform.parent.GetComponentInParent<PCManager> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		manager.Close ();
	}
}
