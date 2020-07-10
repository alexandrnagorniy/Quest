using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelMoveVector2Trigger : MonoBehaviour {
    public AudioClip clip;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        coll.GetComponent<Animator>().SetTrigger ("Move");
		//anim.enabled = true;
		coll.GetComponent<AccelMoveVector2>().aoc.Enter();
		coll.GetComponent<AccelMoveVector2>().StartCoroutine( coll.GetComponent<AccelMoveVector2>().Enter ());
		coll.GetComponent<AccelMoveVector2>().enabled = false;

	}

}
