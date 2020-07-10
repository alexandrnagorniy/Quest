using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
	public bool startEnactive;


	private bool load;
	private string nameInData;
	public MyData posData;
	public InventoryData invData;
	private Inventory inv;
	void Start ()
	{
		load = Camera.main.GetComponent<GameManager> ().load;
		if (gameObject.name == "Inventory")
		{
			nameInData = "Inventory";
			inv = GetComponent<Inventory> ();
		}
		else
			nameInData = gameObject.name + transform.position;

		if (load) {  
			if (nameInData == "Inventory")
				LoadInventory ();
			else
				LoadPosition ();
		} else {
			if (nameInData == "Inventory")
				SaveInventory ();
			else 
			{
				gameObject.SetActive (!startEnactive);
				SavePosition ();
			}
		}
	}

	public void LoadPosition()
	{
		string tempHighScore = PlayerPrefs.GetString (nameInData);
		posData = JsonUtility.FromJson<MyData> (tempHighScore);
		gameObject.SetActive (posData.isActive);
		if(gameObject.name != "MainCamera")
			GetComponent<BoxCollider2D> ().enabled = posData.isCollider;
		transform.localPosition = new Vector3(posData.posX, posData.posY, posData.posZ);
		transform.localScale = new Vector3 (posData.scaleX, posData.scaleY, posData.scaleZ);
		//Debug.Log ("Loaded position: " + gameObject.name);
	}

	public void SavePosition()
	{
		posData.posX = transform.localPosition.x;
		posData.posY = transform.localPosition.y;
		posData.posZ = transform.localPosition.z;
		posData.scaleX = transform.localScale.x;
		posData.scaleY = transform.localScale.y;
		posData.scaleZ = transform.localScale.z;
		posData.isActive = gameObject.activeSelf;
		if(gameObject.name != "MainCamera")
			posData.isCollider = GetComponent<BoxCollider2D> ().enabled;
		PlayerPrefs.SetString (nameInData, JsonUtility.ToJson(posData));
		//Debug.Log ("Saved position" + gameObject.name);
	}

	public void SaveInventory()
	{
		invData.invItem.Clear ();
		//      Debug.Log ();
		for (int i = 0; i < inv.invItem.Count; i++)
		{
			invData.invItem.Add (inv.invItem[i].name);
		}
		PlayerPrefs.SetString ("Inventory", JsonUtility.ToJson(invData));
		Debug.Log ("Saved inventory");
	}

	public void LoadInventory()
	{
		string tempHighScore = PlayerPrefs.GetString ("Inventory");
		Debug.Log(tempHighScore);
		Debug.Log (tempHighScore.Length);
		
		invData = JsonUtility.FromJson<InventoryData> (tempHighScore);
		Debug.Log(invData);
		for (int i = 0; i < invData.invItem.Count; i++)
		{
			Debug.Log(invData.invItem[i]);
			for (int item = 0; item < inv.items.Count; item++)
			{
				if (inv.items [item].name == invData.invItem [i]) 
				{
					inv.invItem.Add (inv.items [item]);
					Debug.Log(invData.invItem[i] + "added");
					break;
				}
			}
		}
		/*if (invData.invItem.Count > 0)
		{
			for (int i = 0; i < invData.invItem.Count; i++)
			{
			Debug.Log(invData.invItem[i]);
				inv.invItem.Add (invData.invItem[i]);
			}

		}*/
		inv.Icons ();
		Debug.Log ("Loaded inventory");
	}
}

[System.Serializable]
public class MyData
{
	public float posX;
	public float posY;
	public float posZ;
	public float scaleX;
	public float scaleY;
	public float scaleZ;
	public bool isActive;
	public bool isCollider;
}

[System.Serializable]
public class InventoryData
{
	public List<string> invItem = new List<string>();
}