using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameDoors : MonoBehaviour {
	public GameObject door3, door6, nextScene;
	public SpriteRenderer[] greens;
	public SpriteRenderer[] reds;
	public int selectGreen;
	private float cd = 2f;
	private float time;
	private int opened;
	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i < greens.Length; i++)
		{
			greens [i].color = Color.blue;
			reds [i].color = Color.red;
		}

		Select ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (opened < 5) {
			if (time > 0) {
				time -= 0.01f;
				greens [selectGreen].color = Color.green;
			} else
				greens [selectGreen].color = Color.blue;
		}
	}

	void Select()
	{
		selectGreen = Random.Range (0, greens.Length);
		if (greens [selectGreen].color != Color.green)
			time = cd;
		else
			Select ();
	}

	void Reset()
	{
		greens [selectGreen].color = Color.blue;
		Select ();
	}

	void Open()
	{
		door3.SetActive (true);
		door6.SetActive (true);
		GameObject.Find ("Effector").GetComponent<DarkEffect> ().Black (nextScene);
		gameObject.SetActive (false);
	}

	public void PressButton(int button, int number)
	{
		if (button == greens [selectGreen].GetComponent<Glass> ().selectNumber) {
			reds [number].color = Color.grey;
			reds [number].GetComponent<BoxCollider2D> ().enabled = false;
			greens [selectGreen].color = Color.green;
			opened++;
			if (opened < 5)
				Select ();
			else
				Open ();
		} 
		else 
		{
			reds [number].color = Color.red;
			Reset ();
		}

	}
}
