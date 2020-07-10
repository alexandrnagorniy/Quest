using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TahoArrow : MonoBehaviour {
	public GameObject door;
	public GameObject camera;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.eulerAngles.z > 0f)
			transform.rotation = Quaternion.Euler (0, 0, transform.eulerAngles.z + 0.25f);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		camera.SetActive (false);
		door.SetActive (true);
		this.enabled = false;
	}
}
