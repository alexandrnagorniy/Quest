using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	public int id;
	public Sprite sprite;
	public Sprite icon;
	public Sprite iconSelected;
	private SpriteRenderer renderer;
	private Inventory inv;
	private bool pickup, pickdown;
	private float sizeX, sizeY, tmpSizeX, tmpSizeY, m = 0.02f;
	public bool parting;
	public string partObject1;
	public string partObject2;
	public string[] partObject;
	public int part;
	public bool deactiveObject;
	public GameObject inactiveInInventory;
	public GameObject dObject;
	public AudioClip pickSound;
	public AudioClip useSound;
	// Use this for initialization
	void Start () 
	{

	}

	void FixedUpdate()
	{
		if(pickup && !pickdown)
		{
			if(transform.localScale.x < tmpSizeX)
			{
				transform.localScale = new Vector2( transform.localScale.x + m, transform.localScale.y + m);
			}
			else
			{
				m *= -1;
                if(pickSound != null)
                AudioSource.PlayClipAtPoint(pickSound, Camera.main.transform.position);
				pickdown = true;
			}
		}
		else if(pickup && pickdown)
		{
			if(transform.localScale.x > sizeX)
			{
				transform.localScale = new Vector2( transform.localScale.x + m, transform.localScale.y + m);
			}
			else
			{
				pickup = false;
				pickdown = false;
				inv.AddItem (this);
				GetComponent<Loader> ().SavePosition (); 
				if (deactiveObject) {
					dObject.SetActive (!dObject.activeSelf);
					dObject.GetComponent<Loader> ().SavePosition ();
				}
				if (inactiveInInventory != null) {
					dObject.SetActive (!dObject.activeSelf);
					inv.Select (inv.invItem.Count - 1);
					inv.Remove ();
					dObject.GetComponent<Loader> ().SavePosition ();
				}
			}
		}
	}

	void OnMouseDown()
	{
		Get();
	}

	public void Get()
	{
		inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		if(inv.slotsCount < 5)
		{
			sizeX = transform.localScale.x;
			sizeY = transform.localScale.y;
			tmpSizeX = sizeX * 1.5f;
			tmpSizeY = sizeY * 1.5f;
			pickup = true;
		}
	}
}