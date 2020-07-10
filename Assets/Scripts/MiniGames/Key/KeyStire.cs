using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStire : MonoBehaviour {
	public KeyManager manager;
	private GameObject go;
	private bool arrow;
	public float minPositionY;
	public float maxPositionY;
	public float step;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		if (arrow)
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - step );
		else 
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + step);

		if (transform.localPosition.y <= minPositionY)
			arrow = false;
		else if (transform.localPosition.y >= maxPositionY)
			arrow = true;
			

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		go = coll.gameObject;
		if (go.name == gameObject.name) {
			manager.Stay ();

		}
		Debug.Log ("1");
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(go.name == gameObject.name)
			manager.Exit ();

	}
}
