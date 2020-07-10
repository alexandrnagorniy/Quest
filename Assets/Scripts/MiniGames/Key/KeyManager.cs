using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {
	public int stay;
	public bool[] stays = new bool[7];
 
    public DarkEffect effector;
	public GameObject nextScene;
    public GameObject script;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Check () 
	{
		if (stay == 5)
        {
//            mycamera.SetActive(false);
			GameObject.Find ("Effector").GetComponent<DarkEffect> ().Black (nextScene);
			Camera.main.GetComponent<Last> ().Oper();
			if (script != null)
				script.SetActive (false);
			gameObject.SetActive (false);
        }
	}

	public void Stay()
	{
		stay++;
		Check ();
	}

	public void Exit()
	{
		stay--;
	}
}
