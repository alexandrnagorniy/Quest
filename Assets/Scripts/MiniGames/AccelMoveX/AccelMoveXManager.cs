using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelMoveXManager : MonoBehaviour {
	public Transform accel;
	private int count;
	public Transform target;
	public GameObject win;
    public GameObject[] openObject;
	public string itemName;
	private bool added;
    public void Enter()
	{
		
	}

	public void Entered()
	{
		count++;
		if (count == 2) 
		{
			GameObject.FindGameObjectWithTag ("Effector").GetComponent<DarkEffect> ().Black (transform.parent.gameObject);
			win.SetActive (true);
			Camera.main.GetComponent<Looker> ().light.SetActive (true);
			Camera.main.GetComponent<Looker> ().light.GetComponent<Loader> ().SavePosition ();
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

	public void Select(Transform tmp)
	{
		target = tmp;
		accel.position = new Vector2 (accel.position.x, target.position.y + 1f);

		//accel.gameObject.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 pos = transform.position;
		Vector2 cam = Camera.main.transform.position;
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
	}
}
