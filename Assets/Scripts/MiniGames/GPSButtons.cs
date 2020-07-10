using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSButtons : MonoBehaviour {
	public GameObject button;
	public GameObject activator;

	void OnMouseDown()
	{
		button.SetActive (true);
		transform.position = new Vector2 (-10000, -10000);
	}

	public void PushButton()
	{
		GameObject.Find ("Effector").GetComponent<DarkEffect> ().Black (activator);
	}
}
