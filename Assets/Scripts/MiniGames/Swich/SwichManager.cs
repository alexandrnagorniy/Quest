using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichManager : MonoBehaviour {
	private int switchers;
	public int need;
	public GameObject[] open;
	public string item1;
	public string item2;
	public Inventory inv;
	private bool activePL;

	void Start()
	{
		inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	}

	private void Delete(string name)
	{
		GameObject.Find(name).transform.position = Vector2.one * -500;
			for (int invCount = inv.invItem.Count - 1; invCount == 0; invCount--) {
			
			if (inv.invItem [invCount].name == name) {
				inv.Select (invCount);
				inv.Remove ();
				break;
				}
		}
	}

	public void Switch (int i) 
	{
		switchers += i;
		if (switchers == need) 
		{
			Camera.main.GetComponent<Looker> ().firstRoom.SetActive (true);
			Camera.main.GetComponent<Looker> ().enabled = false;
			Camera.main.GetComponent<Looker> ().Save ();
			Delete (item1);
			Delete (item2);
			Camera.main.transform.GetChild (0).gameObject.SetActive (false);
			Camera.main.transform.Find("Light").gameObject.GetComponent<Loader> ().SavePosition ();
			for (int o = 0; o < open.Length; o++)
			{
				open[o].SetActive (!open[o].activeSelf);
				open[o].GetComponent<Loader> ().SavePosition ();
			}
			GameObject.Find ("Effector").GetComponent<DarkEffect> ().Black (transform.parent.gameObject);
			activePL = false;
		}
	}

	void Update()
	{
		float dist = Vector2.Distance (transform.position, Camera.main.transform.position);
		if (dist == 0 && !activePL)
			activePL = true;
		if (switchers < need && dist > 20 && activePL) 
		{
			Camera.main.transform.Find ("Light").gameObject.SetActive (true);
			Camera.main.transform.Find("Light").gameObject.GetComponent<Loader> ().SavePosition ();
			activePL = false;
		}
	}
}
