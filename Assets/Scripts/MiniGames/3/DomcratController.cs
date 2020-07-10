using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomcratController : MonoBehaviour {
	public Transform bar;
	int x;
	public GameObject[] sprite;
	public GameObject unlockObj, unlObj, nextScene;
	bool move;
	// Use this for initialization
	void Start () 
	{
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (x == 3 && !move)
		{
			unlockObj.SetActive (true);
			unlObj.SetActive (true);
			Input.gyro.enabled = false;
			GameObject.Find ("Effector").GetComponent<DarkEffect> ().Black (nextScene);
			move = true;
			transform.parent.gameObject.SetActive (false);
		}
			
		transform.rotation = Quaternion.Euler (0, 0, transform.eulerAngles.z + Input.acceleration.x);
		float direction = 8f;
		if (transform.eulerAngles.z > 0) {
			if (direction < 0)
				direction *= -1;
		} else if (transform.eulerAngles.z < 0) {
			if (direction > 0)
				direction *= -1;
		}
		bar.position = new Vector2 (transform.position.x + direction * (transform.eulerAngles.z / 360), bar.position.y);

	}

	public void Add()
	{
		x++;
		sprite [x - 1].SetActive (true);
	}
}
