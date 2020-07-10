using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectFromCamera : MonoBehaviour {
    public GameObject firstPaner;
    private bool first = true;
    public GameObject secondPanel;
    private Vector2 cam;
    private Vector2 mePos;
	// Use this for initialization
	void Start () {
		if (Camera.main.GetComponent<GameManager> ().load)
			first = System.Convert.ToBoolean( PlayerPrefs.GetInt ("Morph"));
        mePos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        cam = Camera.main.transform.position;
        if (cam == mePos)
        {
            firstPaner.SetActive(first);
            secondPanel.SetActive(!first);
        }
        else
        {
            firstPaner.SetActive(false);
            secondPanel.SetActive(false);
        }
		PlayerPrefs.SetInt ("Morph", System.Convert.ToInt32(first));
	}

    public void Enter()
    {
        first = false;
    }
}
