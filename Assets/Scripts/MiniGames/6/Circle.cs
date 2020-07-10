using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{

    private bool stay;
    public float gradus;
	public bool rotating;
    // Use this for initialization
    void Start()
    {
		if (!rotating) {
			transform.rotation = Quaternion.Euler (0, 0, Random.Range (1, 13) * 30);
			if (transform.rotation == Quaternion.Euler (0, 0, gradus)) {
				transform.rotation = Quaternion.Euler (0, 0, Random.Range (1, 13) * 30);
				Start ();
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
		if (!rotating) {
			transform.Rotate (0, 0, -30);
			if (transform.rotation == Quaternion.Euler (0, 0, gradus)) {
				
			} else {
				if (stay == true) {
					GetComponentInParent<CircleManager> ().Exit ();
					stay = false;
				}
			}
		} else {
			if (!stay) 
			{
				stay = true;
				GetComponentInParent<CircleManager> ().Enter ();
				GetComponent<SpriteRenderer> ().sprite = GetComponentInParent<CircleManager> ().sprite;
			}
		}

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
		Debug.Log ("Entered");
        GetComponentInParent<CircleManager>().Enter();
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        GetComponentInParent<CircleManager>().Exit();

    }

    
}
