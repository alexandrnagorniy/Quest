using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStickManager : MonoBehaviour {
	private int entered;
	public void Entered()
	{
		entered++;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
				if (entered == 6) {
			Camera.main.GetComponent<EndGame> ().EnterTheCar ();
			gameObject.SetActive (false);
			GetComponent<Loader> ().SavePosition ();
		}
	}
}
