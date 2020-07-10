using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject canvas;
	private Loader data;
	public bool load = false;
	public Testing test;
	void Awake()
	{
		PlayerPrefs.SetInt ("Play", 1);
		load = System.Convert.ToBoolean (PlayerPrefs.GetInt("Load"));
		if (load && test != null)
			test.Load ();
		//load = true;
	}

	void Start () 
	{
		data = GetComponent<Loader> ();
	}
		
	void Update () 
	{
		//load = false;
	}

	void FixedUpdate()
	{
		
	}
}