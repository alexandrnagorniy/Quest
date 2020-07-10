using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActive : MonoBehaviour {
	public GameObject camera;
	void OnMouseDown()
	{
		camera.SetActive (true);
	}
}
