using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroPart : MonoBehaviour {
	public ElectroManager manager;
	public int goodStay;
	public bool good;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () 
	{
		transform.rotation = Quaternion.Euler(0, 0,transform.eulerAngles.z - 90);
		if (good && transform.eulerAngles.z == goodStay) {
			manager.Part ();
			//GetComponent<BoxCollider2D> ().enabled = false;
			//1this.enabled = false;
		}
        else
            manager.reset = true;
        manager.Rotate();
	}
}
