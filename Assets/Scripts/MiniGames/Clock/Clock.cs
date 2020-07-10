using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {
	public GameObject key;
	private int arrows;
	public GameObject camera;
	public GameObject miniGame;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (arrows == 2) {
			camera.SetActive (false);
			key.SetActive (true);
			miniGame.SetActive (false);
		}
	}

	public void Stay()
	{
		arrows++;
	}

	public void Exit()
	{
		arrows--;
	}
}
