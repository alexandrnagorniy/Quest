using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	private int language;
	private int sound;
	public GameObject loadGame;
	public GameObject option;
	// Use this for initialization
	void Start () 
	{
		//GetComponent<Loader> ().LoadInventory ();
		LoadSettings ();
		loadGame.SetActive(System.Convert.ToBoolean( PlayerPrefs.GetInt ("Play")));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadGame()
	{
		SaveSettings ();
		PlayerPrefs.SetInt ("Load", 1);
		SceneManager.LoadSceneAsync ("Level1");
	}

	void LoadSettings()
	{
		language = PlayerPrefs.GetInt ("Language");
		sound = PlayerPrefs.GetInt ("Sound");
	}

	void SaveSettings()
	{
		PlayerPrefs.SetInt ("Language",language);
		PlayerPrefs.SetInt ("Sound",sound);
	}

	public void Play()
	{
		SaveSettings ();
		PlayerPrefs.SetInt ("Load", 0);
		SceneManager.LoadSceneAsync ("Level0");
	}

	public void Option()
	{
		option.SetActive(!option.activeSelf);
	}

	public void Exit()
	{
		SaveSettings ();
		Application.Quit ();
	}

	public void Sound(int value)
	{
		sound = value;
	}

	public void Language(int value)
	{
		language = value;
	}

}
