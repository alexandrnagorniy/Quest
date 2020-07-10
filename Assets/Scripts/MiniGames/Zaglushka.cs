using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaglushka : MonoBehaviour
{
    public Looker look;
	private int o;
    // Use this for initialization
    void OnEnable()
    {
		gameObject.SetActive (false);
		GetComponent<Loader> ().SavePosition ();
    }

    // Update is called once per frame
    void OnDisable()
    {
		o++;
		if(o == 2)
        	look.spot1 = true;
    }
}