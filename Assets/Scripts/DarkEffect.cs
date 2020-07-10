using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEffect : MonoBehaviour {
	private SpriteRenderer sprite;
	private GameObject camera;
	public GameObject nextScene;
	private bool black;
	private float color;
	public GameObject canvas;

	// Use this for initialization
	void Start () 
	{
		camera = Camera.main.gameObject;
		sprite = GetComponent<SpriteRenderer>();
		//camera.transform.position = new Vector3 (0, 0, -10);
		//Black (nextScene);
	}

	void Update()
	{
		transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, -9); 
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, -9); 
		GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, color);
		if(black == true && color < 1)
			color += 0.025f;
		else if(black == true && color >= 1)
		{
			camera.transform.position = new Vector3(nextScene.transform.position.x, nextScene.transform.position.y, -10);
			//camera.GetComponent<Testing> ().AddData ("Move to :" + nextScene.name);
			black = false;
			camera.GetComponent<Loader> ().SavePosition ();
			if(nextScene.name == "Lock" && canvas.activeSelf)
				canvas.SetActive(false);
			else
				canvas.SetActive(true);
	
		}
		else if(black == false && color > 0)
			color -= 0.025f;

	}

	public void Black(GameObject pos)
	{
     // if(nextScene != null)
    // nextScene.GetComponent<AudioSource>().Stop();
        nextScene = pos;
    //   nextScene.GetComponent<AudioSource>().Play();
        black = true;
	}
}