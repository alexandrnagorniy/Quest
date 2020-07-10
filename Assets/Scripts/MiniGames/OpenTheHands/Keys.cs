using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {
	public float force;
	public Rigidbody2D[] rig;
	public bool[] stays;
	public int i;
	public Rigidbody2D select;
	private GameManager manager;
	// Use this for initialization
	void Start () 
	{
		manager = Camera.main.GetComponent<GameManager>();
		select = rig[0];	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
			rig[i].AddForce(Vector2.up * force);
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(stays[i] == false)
			{
				for(int n = 0; n < rig.Length - 1; n++)
				{
					if(rig[n].isKinematic)
						rig[n].isKinematic = false;
				}
				i = 0;
			}
			else
			{
				rig[i].velocity = Vector2.zero;
				rig[i].isKinematic = true;
				if(i < rig.Length - 1)
					i++;
			//	else
			//		manager.OpenTheLock();
			}
		}
	}
}
