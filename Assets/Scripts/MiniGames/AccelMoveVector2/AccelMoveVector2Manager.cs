using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelMoveVector2Manager : MonoBehaviour {
	public GameObject nextScene;
	private Vector2 cam;
	public GameObject accel;
	private bool enter;
	public GameObject[] openObject;
	public string itemName;
	private bool added;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {
		cam = Camera.main.transform.position;
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
		else if (cam != pos)
			added = false;
		accel.SetActive (cam == (Vector2)transform.position);
	}

	public void Enter()
	{
		GameObject.FindGameObjectWithTag ("Effector").GetComponent<DarkEffect> ().Black (nextScene);
		for (int i = 0; i < openObject.Length; i++) { openObject[i].SetActive(!openObject[i].activeSelf); 
			openObject[i].GetComponent<Loader> ().SavePosition ();}
		gameObject.SetActive (false);
		GetComponent<Loader> ().SavePosition ();
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
