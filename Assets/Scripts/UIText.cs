using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIText : MonoBehaviour
{
    public bool noCheckPosition;
    public AllUIText textUI;
    public string[] languageText = new string[2];
    private int language;
    public bool isComix;
    // Use this for initialization
    void Start()
    {
		language = PlayerPrefs.GetInt("Language");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isComix)
        {
            if (!noCheckPosition)
            {
                if (transform.position.x == Camera.main.transform.position.x && transform.position.y == Camera.main.transform.position.y)
                {
                    Text();
                }
            }
            else if (noCheckPosition)
            {
                Text();
            }
        }
        else
        {
			GetComponent<Text> ().text = languageText [language];
        }
    }

    void Text()
    {
		textUI.EnterTheText (languageText [language]);
		this.enabled = false;
    }
}