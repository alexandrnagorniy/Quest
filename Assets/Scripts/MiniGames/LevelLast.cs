using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLast : MonoBehaviour {
	public int secondFromNextScene;
	// Use this for initialization
	void Start () {
		StartCoroutine (Timer ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator Timer()
	{
		yield return new WaitForSeconds (secondFromNextScene);
		SceneManager.LoadScene ("Menu");
	}
}
