using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> invItem = new List<Item>();
    public int slotsCount;
    public Item select;
    private int lastSelectNumber;
    private string tmpPart;
    public Image[] slots;
    public Image[] slotsSelect;
    public Sprite selectImage;
    public Sprite clear;
    public GameObject go;
    public GameObject phone;
	public Loader loader;
	public List<Item> items = new List<Item> ();

	void Start()
	{
		loader = GetComponent<Loader> ();
        Icons();
    }

    public void Remove()
    {
        invItem.Remove(select);
//		Camera.main.GetComponent<Testing> ().AddData ("Removed item " + select.name);
		loader.SaveInventory ();
		select = null;
        Icons();
    }

    public void Icons()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < invItem.Count)
                slots[i].sprite = invItem[i].icon;
            else
                slots[i].sprite = clear;
            slotsSelect[i].sprite = clear;
        }
    }

    public void AddItem(Item item)
    {
        invItem.Add(item);
        slots[invItem.Count - 1].sprite = item.icon;
        item.gameObject.transform.position = new Vector3(-50, -50, -50);
		loader.SaveInventory ();
		//Camera.main.GetComponent<Testing> ().AddData ("Added item " + item.gameObject.name);
    }

    void FixedUpdate()
    {
        slotsCount = invItem.Count;
    }

    void NotPart(int number)
    {
        for (int i = 0; i < invItem.Count; i++)
        {
            if (invItem[i].Equals(select))
            {
                slots[lastSelectNumber].sprite = select.icon;
                slotsSelect[lastSelectNumber].sprite = clear;
                select = invItem[number];
                slots[number].sprite = select.iconSelected;
                slotsSelect[number].sprite = selectImage;
                lastSelectNumber = number;
                break;
            }
            else if (i == invItem.Count - 1)
            {
                select = invItem[number];
                slots[number].sprite = select.iconSelected;
                slotsSelect[number].sprite = selectImage;
                lastSelectNumber = number;
                break;
            }
        }
    }

    void Part(int number, string part)
    {
        Item tmp = invItem[number];
        Remove();
        select = tmp;
        Remove();
        Item add = GameObject.Find(part).GetComponent<Item>();
        AddItem(add);
		loader.SaveInventory ();
    }

    public void Select(int selectNumber)
    {
        if (select != null && invItem.Count > selectNumber)
        {
            if (invItem[selectNumber] != select)
            {
                if (!select.parting)
                {
                    NotPart(selectNumber);

                }
                else
                {
                    if (invItem[selectNumber].parting)
                    {

                        /*if ((select.partObject1 == invItem [selectNumber].partObject1) ||
						    (select.partObject2 == invItem [selectNumber].partObject1) ||
						    (select.partObject1 == invItem [selectNumber].partObject2) ||
						    (select.partObject2 == invItem [selectNumber].partObject2)) 
						{
							if (select.partObject1 == invItem [selectNumber].partObject1)
								tmpPart = select.partObject1;
							else if (select.partObject1 == invItem [selectNumber].partObject2)
								tmpPart = select.partObject1;
							else if (select.partObject2 == invItem [selectNumber].partObject1)
								tmpPart = select.partObject2;
							else if (select.partObject2 == invItem [selectNumber].partObject2)
								tmpPart = select.partObject2;*/
                        for (int i = 0; i < select.partObject.Length; i++)
                        {
                            Debug.Log(select.name + " : i = " + i);
                            for (int n = 0; n < invItem[selectNumber].partObject.Length; n++)
                            {
                                Debug.Log(select.name + " : n = " + n);
                                if (select.partObject[i] == invItem[selectNumber].partObject[n])
                                {
                                    tmpPart = select.partObject[i];
                                    Part(selectNumber, tmpPart);
                                    break;
                                }
                            }
                            if (tmpPart != null)
                            {
                                break;
                            }
                        }
                        tmpPart = null;
                        //if(tmpPart == null)
                        //	NotPart (selectNumber);
                    }
                    else
                        NotPart(selectNumber);
                }
            }
            else
            {
                slots[selectNumber].sprite = select.icon;
                slotsSelect[selectNumber].sprite = clear;
                select = null;
            }
        }
        else
        {
            if (selectNumber <= invItem.Count - 1)
            {
                select = invItem[selectNumber];
                slots[selectNumber].sprite = select.iconSelected;
                slotsSelect[selectNumber].sprite = selectImage;
                lastSelectNumber = selectNumber;
            }
        }
    }

    void Un()
    {
        go.SetActive(!go.activeSelf);
    }
}