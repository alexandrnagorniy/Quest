using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour {
	public int selectNumber;
	public int myNumber;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < GetComponentInParent<MiniGameDoors> ().reds.Length; i++) 
		{
			if (GetComponentInParent<MiniGameDoors> ().reds [i].name == gameObject.name) 
			{
				myNumber = i;
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		GetComponentInParent<MiniGameDoors> ().PressButton (selectNumber, myNumber);
	}
}
