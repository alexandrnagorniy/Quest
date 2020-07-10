using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour
{
    public Inventory inv;
    public GameObject light;
    public Transform room;
    public GameObject firstRoom;
    public bool spot1;
    public bool spot2;
    public GameObject black;
    private bool pickup, pickdown;
    private float sizeX, sizeY, minx, maxx, m = 0.02f;
	public GameManager manager;
	public Transform lichRoom;
    // Use this for initialization
	public void Save()
	{
		PlayerPrefs.SetInt ("Looker", System.Convert.ToInt32(this.enabled));
	}

    void Start()
    {
		manager = GetComponent<GameManager> ();
		Debug.Log (PlayerPrefs.GetInt ("Looker"));
		if (manager.load) 
		{
			bool enable = System.Convert.ToBoolean (PlayerPrefs.GetInt ("Looker"));
			if (enable) 
			{
				spot1 = System.Convert.ToBoolean (PlayerPrefs.GetInt ("LookerSpot1"));
				spot2 = System.Convert.ToBoolean (PlayerPrefs.GetInt ("LookerSpot2"));
			}
			else
				this.enabled = false;
		}
		StartCoroutine (Saver ());
    }

	IEnumerator Saver()
	{
		PlayerPrefs.SetInt ("LookerSpot1", System.Convert.ToInt32 (spot1));
		PlayerPrefs.SetInt ("LookerSpot2", System.Convert.ToInt32 (spot2));
		PlayerPrefs.SetInt ("Looker", System.Convert.ToInt32(this.enabled));
		yield return new WaitForSeconds (1);
		StartCoroutine (Saver ());
	}

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if (inv.invItem.Count > 0)
        {
            for (int i = inv.invItem.Count - 1; i >= 0; i--)
            {
                if (pos == new Vector2(room.position.x, room.position.y) && inv.invItem[i].name != "Inventory_0 (1)" && !spot1)
                {
                    Debug.Log("2");
                    black.SetActive(true);
                }
                else if (pos != new Vector2(room.position.x, room.position.y) && inv.invItem[i].name != "Inventory_0 (1)" && !spot1)
                {
                    Debug.Log("3");
                    black.SetActive(false);
                }
				else if (pos == new Vector2(room.position.x, room.position.y) && inv.invItem[i].name == "Inventory_0 (1)" &&  !spot1)
                {
                    Debug.Log("8");
                    black.SetActive(true);
                }
                else if (pos != new Vector2(room.position.x, room.position.y) && inv.invItem[i].name == "Inventory_0 (1)" && !spot1)
                {
                    Debug.Log("8");
                    black.SetActive(false);
                }
                    if (inv.invItem[i].name == "Inventory_3 (1)" && !spot2)
                {
                    Debug.Log("4");
                    spot2 = true;
                    break;
                }
                if (inv.invItem[i].name == "Inventory_3" && spot2)
                {
                    Debug.Log("5");
                    for (int n = inv.invItem.Count - 1; n >= 0; n--)
                    {
                        if (inv.invItem[n].name == "Inventory_3 (1)")
                        {
                            inv.Select(n);
                            inv.Remove();
                            break;
                        }
                    }
                    light.transform.localScale = Vector3.one * 2f;
                    inv.Select(i);
                    inv.Remove();
					light.GetComponent<Loader> ().SavePosition ();
                    break;
                }
            }
        }
        else if (pos == new Vector2(room.position.x, room.position.y) && inv.invItem.Count == 0 && !spot1)
        {
            Debug.Log("6");
            black.SetActive(true);
        }
        else if (pos == new Vector2(room.position.x, room.position.y) && spot1 && !spot2)
        {
            Debug.Log("10");
            black.SetActive(false);
            Debug.Log("9");
            light.SetActive(true);
			light.GetComponent<Loader> ().SavePosition ();
            //  light.transform.localScale = Vector3.one * 1.25f;
            firstRoom.SetActive(false);
            minx = 0.75f;
            maxx = 1.25f;
            pickup = true;
        }
        else if (pos != new Vector2(room.position.x, room.position.y) && inv.invItem.Count == 0 && !spot1)
        {
            black.SetActive(false);
            Debug.Log("7");
        }

		if (pos == new Vector2( lichRoom.position.x, lichRoom.position.y)) 
		{
			light.SetActive (false);
		}

        if (spot1 && !spot2)
        {
            if (pickup && !pickdown)
            {
                if (light.transform.localScale.x <= minx)
                {
                    light.transform.localScale = new Vector2(light.transform.localScale.x + m, light.transform.localScale.y + m);
                }
                else
                {
                    m *= -1;
                    pickdown = true;
                    pickup = false;

                }
            }
            if (!pickup && pickdown)
            {
                if (light.transform.localScale.x >= maxx)
                {
                    light.transform.localScale = new Vector2(light.transform.localScale.x + m, light.transform.localScale.y + m);
                }
                else
                {
                    m *= -1;
                    pickdown = false;
                    pickup = true;

                }
            }
        }
    }
}
