using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AllUIText : MonoBehaviour
{
    public Text text;
    private float cd;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (cd > 0)
            cd -= Time.deltaTime;
        else
        {
            text.text = null;
            text.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }


    }

    public void EnterTheText(string tmpText)
    {
        gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = tmpText;
        cd = 3f;
    }
}
