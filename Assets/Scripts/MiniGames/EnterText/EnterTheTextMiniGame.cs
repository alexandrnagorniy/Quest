using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterTheTextMiniGame : MonoBehaviour {
	public GameObject questionPanel;
	public GameObject inputGO;
	public Text inputText;
	public Text questionText;
	private int langeage;
	public string[] question;
	public string[] answer;
	private int needQuestion;
	private Vector2 cam;
	private Vector2 pos;
	private bool goodAnswer;
	// Use this for initialization
	void Start () {
		pos = transform.position;
		langeage = PlayerPrefs.GetInt ("Language");
		if (Camera.main.GetComponent<GameManager> ().load) 
		{
			bool good = System.Convert.ToBoolean (PlayerPrefs.GetInt ("GoodAnswer"));
			string loadedText = PlayerPrefs.GetString ("TextETT");

			inputGO.SetActive (!good);
			questionText.text = loadedText;
		}
		else
			questionText.text = question[langeage];
	}
	
	// Update is called once per frame
	void Update ()
	{
		cam = Camera.main.transform.position;
		PlayerPrefs.SetInt ("GoodAnswer", System.Convert.ToInt32 (goodAnswer));
		PlayerPrefs.SetString ("TextETT", questionText.text);
		questionPanel.SetActive (Vector2.Distance (pos, cam) < 10);	
	}

	public void OkButton()
	{
		string tmp = inputText.text;
	
		for(int i = 0; i < answer.Length; i++)
		{
			if (tmp == answer [i]) 
			{
				inputGO.SetActive (false);
				questionText.text = "... 92745";
				goodAnswer = true;
				break;
			}
		}
		inputText.text = null;
	}
}
