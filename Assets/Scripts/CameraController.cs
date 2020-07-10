using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject nextScene;
	private DarkEffect effector;
	public bool disableActivation;
	private int activation;
	public GameObject disableObject;
	// Use this for initialization
	void Start () {

		effector = GameObject.FindGameObjectWithTag("Effector").GetComponent<DarkEffect>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
        if ((disableActivation && activation == 0) || !disableActivation)
        {
			if (nextScene.activeSelf == false) {
				nextScene.SetActive (true);
				nextScene.GetComponent<Loader> ().SavePosition ();
			}
			effector.Black(nextScene);
        }
		activation++;
		if (disableObject != null) 
		{
			disableObject.SetActive (!disableObject.activeSelf);
			disableObject.GetComponent<Loader> ().SavePosition ();
		}
	}
}