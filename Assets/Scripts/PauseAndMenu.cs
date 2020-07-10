using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseAndMenu : MonoBehaviour {
	private bool isPaused;
	public GameObject menuButton;
	private Vector3 lastPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Push () {
		isPaused = !isPaused;
		if (isPaused) {
			lastPos = Camera.main.transform.position;
			Camera.main.transform.position = new Vector3 (1000, 1000, 1000);
		} else
			Camera.main.transform.position = lastPos;
			menuButton.SetActive (isPaused);
	}

	public void GoToMenu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
