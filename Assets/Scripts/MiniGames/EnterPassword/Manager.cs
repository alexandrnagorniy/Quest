using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
	private int lenght;
	public bool nonText;
	private string _text;
	public TextMesh text;
	public string number;
	public int maxNumber;
	public GameObject nextScene;
	public GameObject openObject;
	public GameObject closedObject;
    public GameObject closedObject2;
	public bool deleteFromInventory;
    public SpriteRenderer[] sprite;
	public string nameInInventory;
	private Inventory inv;
	public bool nonButton;
	void Start()
	{
		inv = GameObject.Find ("Inventory").GetComponent<Inventory>();
	//	text.text = null;
	}

	void Push(int i)
	{
		_text += i.ToString ();
		lenght++;
	}

	void End()
	{
		if(deleteFromInventory)
		{
			for (int n = inv.invItem.Count - 1; n == 0; n--) 
			{
				if (inv.invItem [n].name == nameInInventory)
				{
					inv.Select (n);
					inv.Remove ();
					inv.gameObject.GetComponent<Loader> ().SaveInventory ();
				}
			}
		}
		if (gameObject.name != "GPS") 
		{
			if (openObject != null) {
				openObject.SetActive (!openObject.activeSelf);
				openObject.GetComponent<Loader> ().SavePosition ();
			}
			if (closedObject != null)
			{
				if (closedObject.name == "Button (2)") 
				{
					if(closedObject.activeSelf)
						closedObject.SetActive (!closedObject.activeSelf);
				}
				else
					closedObject.SetActive (!closedObject.activeSelf);
				closedObject.GetComponent<Loader> ().SavePosition ();
			}
			if (closedObject2 != null) {
				closedObject2.SetActive (!closedObject2.activeSelf);
				closedObject2.GetComponent<Loader> ().SavePosition ();
			}
            gameObject.SetActive (false);
			GetComponent<Loader> ().SavePosition ();
		}
		else
		{
			openObject.SetActive (false);
			_text = null;
			Camera.main.GetComponent<Last> ().Oper ();
		}
		GameObject.Find ("Effector").GetComponent<DarkEffect> ().Black (nextScene);
	}

	void Reset()
	{
		lenght = 0;
		_text = null;
        if (sprite.Length > 0)
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                sprite[i].color = Color.clear;
            }
        }
	}

	public void PushButton(int i)
	{
		if (!nonButton) 
		{
			if (i < 10) {
				if (lenght < maxNumber) {		
					Push (i);
				}
			} else {
				if (_text == number)
					End ();
				else
					Reset ();
			
			}
		}
		else 
		{
			if (lenght < maxNumber - 1) 
			{		
				Push (i);
			}
			else 
			{
				if (_text == number)
					End ();
				else
					Reset ();
			}
		}
	}
    /// <summary>
    /// /щя
    /// </summary>
	void LateUpdate()
	{
		if(!nonText)
			text.text = _text;
	}
} 