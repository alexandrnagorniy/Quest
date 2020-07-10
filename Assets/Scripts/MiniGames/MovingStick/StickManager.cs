using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickManager : MonoBehaviour {
	private int stay;
	public int StayInt{
		get{ return stay; }
	}
	public int stayCount;
    public GameObject[] openObject;
	// Update is called once per frame
	void FixedUpdate () {
		if (stayCount == stay) {
			GameObject.FindGameObjectWithTag ("Effector").GetComponent<DarkEffect> ().Black (transform.parent.gameObject);
			for (int i = 0; i < openObject.Length; i++) { openObject[i].SetActive(!openObject[i].activeSelf); }
			this.enabled = false;
			GetComponent<Loader> ().SavePosition ();
		}
	}


	public void Stay(int i)
	{
		stay += i;
	}
}
