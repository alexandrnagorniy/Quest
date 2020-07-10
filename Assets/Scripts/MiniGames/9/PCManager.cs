using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCManager : MonoBehaviour {
	public GameObject monitorActive;
	public GameObject monitorDeactive;
	public GameObject panel;
	public Sprite[] spriteLanguage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Open(int picture)
	{
		Debug.Log ("Open");
		panel.GetComponent<SpriteRenderer>().sprite = spriteLanguage [picture * 2];
		monitorActive.SetActive (false);
		monitorDeactive.SetActive (true);
		panel.SetActive (true);
	}

	public void Close()
	{
		monitorActive.SetActive (true);
		monitorDeactive.SetActive (false);
		panel.SetActive (false);
	}
}
