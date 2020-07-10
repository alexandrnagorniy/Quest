using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour {
	public int open;
	public int openCount;
	public bool move;
	public GameObject unlockObj;
	public GameObject nextScene;
	public GameObject disableObject;
	public Sprite sprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (open == openCount && !move) 
		{
			if(unlockObj != null)
				unlockObj.SetActive (true);
			if (disableObject != null)
				disableObject.SetActive (false);
			GameObject.Find ("Effector").GetComponent<DarkEffect> ().Black (nextScene);
			if(gameObject.name == "Oil")
				Camera.main.GetComponent<OpenController> ().Oper ();
			move = true;
		}
	}

	public void Enter()
	{
		open++;
	}

	public void Exit()
	{
		open--;
	}
}
