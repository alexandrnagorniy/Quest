using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveObjWithTime : MonoBehaviour {
	public float time;
	//public GameObject[] go;
	// Use this for initialization
	void OnEnabled () {
		StartCoroutine (WaitFromTime());
	}
	
	IEnumerator WaitFromTime()
	{
		yield return new WaitForSeconds(time);
		gameObject.SetActive (false);
	}
}
