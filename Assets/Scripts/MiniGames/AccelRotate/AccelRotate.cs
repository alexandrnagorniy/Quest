using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelRotate : MonoBehaviour {
	private bool isSelect;
	float z;
	public AccelRotateManager manager;
	public AudioClip clip;
	// Use this for initializa tion
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.select == gameObject) 
		{
			GetComponent<SpriteRenderer> ().color = Color.grey;
			if (Input.acceleration.x > 0) {
				z = Input.acceleration.x;
				if (clip != null)
					AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
			}
			//if (Input.GetAxis("Horizontal") > 0)
			//	z = Input.GetAxis("Horizontal");
			transform.Rotate (0, 0, z * -2);

			if (transform.eulerAngles.z < 2)
				manager.Opened ();
		}
		else
			GetComponent<SpriteRenderer> ().color = Color.white;
	}

	void OnMouseDown()
	{
		manager.Select (gameObject);
	}
}
