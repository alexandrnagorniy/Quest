using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
	public GameObject photos;
	public int photo;
	public Text photoText;
	private Inventory inv;
	private bool havePhotos;
	private bool car;
	public GameObject text;
	public Vector2 last;
	public Transform lastLocation;
    public AudioClip clip;
	// Use this for initialization
	void Start () {
		last = lastLocation.position;
		inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		if (Camera.main.GetComponent<GameManager> ().load)
			Load ();
		StartCoroutine (SaveCoroutine ());
	}

	IEnumerator SaveCoroutine()
	{
		yield return new WaitForSeconds (1);
		Save ();
	}

	// Update is called once per frame
	void Update () 
	{
		Vector2 myPos = transform.position;
		photoText.text = photo.ToString ();
		if (photo == 3) 
		{
			Debug.Log ("En0");
			for (int i = inv.invItem.Count - 1; i >= 0; i--) {
				Debug.Log ("for");
				if (inv.invItem [i].name == "Inventory_24 (14)") {
					inv.Select (i);
					inv.Remove ();
					inv.GetComponent<Loader> ().SaveInventory ();
					break;
				}
			}
			havePhotos = true;
		}
		if (car && havePhotos) 
		{
			for (int invCount = inv.invItem.Count - 1; invCount == 0; invCount--) 
			{
				if (inv.invItem [invCount].name == "Inventory_24 (13)" && myPos == last) 
				{
                    if (clip != null)
                        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
                    SceneManager.LoadScene("Final");
				}
			}
		}
		photos.SetActive (photo > 0);
	}

	public void EnterTheCar()
	{
		car = true;
		Save ();
	}

	void Save()
	{
		PlayerPrefs.SetInt ("Photo", photo);
		PlayerPrefs.SetInt ("InCar", System.Convert.ToInt32(car));
	}

	void Load()
	{
		photo = PlayerPrefs.GetInt ("Photo");
		car = System.Convert.ToBoolean(PlayerPrefs.GetInt("InCar"));
	}

	public void Photo()
	{
		if (!photos.activeSelf)
			photos.SetActive (true);
		photo++;
		Save ();
	}
}
