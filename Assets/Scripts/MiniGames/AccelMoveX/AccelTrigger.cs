using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelTrigger : MonoBehaviour {
	public AccelMoveXManager manager;
	private int enter;
    public AudioClip clip;
	// Use this for initialization
	void Start () {
		
	}

	void OnMouseDown()
	{
		manager.Select (transform);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		enter++;
            if (clip != null)
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
		if (enter == 8) 
		{
            manager.Entered ();
			gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
