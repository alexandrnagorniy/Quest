using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelRotateManager : MonoBehaviour {
	public GameObject select;
	private int open;
	public GameObject next;
	public GameObject[] unlockObjects;
    public AudioClip clip;
	public string itemName;
	private bool added;
	// Use this for initialization
	void Start () {
		
	}

	public void Select(GameObject tmp)
	{
		select = tmp;
	}

	public void Opened()
	{
		Destroy (select);
		open++;
		if (open == 4) {
            if (clip != null)
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            GameObject.FindGameObjectWithTag ("Effector").GetComponent<DarkEffect> ().Black (next);
			if (unlockObjects.Length > 0)
				for (int i = 0; i < unlockObjects.Length; i++) {
					unlockObjects [i].SetActive (!unlockObjects [i].activeSelf);
					unlockObjects [i].GetComponent<Loader> ().SavePosition ();
				}
			gameObject.SetActive (false);
			gameObject.GetComponent<Loader> ().SavePosition ();
			for (int i = 0; i < GameObject.Find ("Inventory").GetComponent<Inventory> ().invItem.Count; i++)
			{
				if (GameObject.Find ("Inventory").GetComponent<Inventory> ().invItem [i].name == itemName) 
				{
					GameObject.Find ("Inventory").GetComponent<Inventory> ().Select (i);
					GameObject.Find ("Inventory").GetComponent<Inventory> ().Remove ();
					break;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
		Vector2 cam = Camera.main.transform.position;
		Vector2 pos = transform.position;
		if (cam == pos && !added)
		{
			for (int i = 0; i < GameObject.Find ("Inventory").GetComponent<Inventory> ().invItem.Count; i++) {
				if (GameObject.Find ("Inventory").GetComponent<Inventory> ().invItem [i].name == itemName) {
					GameObject.Find ("Inventory").GetComponent<Inventory> ().Select (i);
					GameObject.Find ("Inventory").GetComponent<Inventory> ().Remove ();
				}
			}
			GameObject.Find ("Inventory").GetComponent<Inventory> ().AddItem (GameObject.Find (itemName).GetComponent<Item> ());
			GameObject.Find ("Inventory").GetComponent<Loader> ().SaveInventory ();
			added = true;
		} 
		else if(cam != pos)
		{
			select = null;
			added = false;
		}
	}
}
