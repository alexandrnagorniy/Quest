using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benzin : MonoBehaviour
{
    private bool stay;
    public float gradus;
    // Use this for initialization
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(1, 13) * 30);
        if (transform.rotation == Quaternion.Euler(0, 0, gradus))
            GetComponentInParent<CircleManager>().Enter();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        transform.Rotate(0, 0, -30);
        if (transform.rotation == Quaternion.Euler(0, 0, gradus))
        {
            stay = true;
            GetComponentInParent<CircleManager>().Enter();
        }
        else
        {
            if (stay == true)
            {
                GetComponentInParent<CircleManager>().Exit();
                stay = false;
            }
        }



    }
}