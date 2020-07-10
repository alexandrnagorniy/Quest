using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour {
	private BoxCollider2D coll;
	void Awake()
	{
		if (Camera.main.GetComponent<GameManager> ().load)
			this.enabled = System.Convert.ToBoolean (PlayerPrefs.GetInt (gameObject.name + "Photo"));
	}
	// Use this for initialization
	void Start () 
	{
		coll = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	public void PhotoGO () 
	{
		Camera.main.GetComponent<EndGame> ().Photo ();
		this.enabled = false;
		PlayerPrefs.SetInt (gameObject.name + "Photo", System.Convert.ToInt32 (this.enabled));
	}
}