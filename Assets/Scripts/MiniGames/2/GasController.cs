using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasController : MonoBehaviour {
	public int count;
	public int x;
	public SpriteRenderer[] renderer;
	public float minX, maxX, minY, maxY, speed;
	public GameObject minObj, maxObj, nextScene;
	private float xMovePosition, yMovePosition;
	// Use this for initialization
	void Start () 
	{
		CheckAcceleration (Input.acceleration.x, Input.acceleration.y);
	}

	void CheckAcceleration(float xValue, float yValue)
	{
	/*	float xPosition = Input.acceleration.x;
		float yPosition = Input.acceleration.y;
		xMovePosition = xPosition - xValue;
		yMovePosition = yPosition - yValue;

		CheckAcceleration (xPosition, yPosition);*/
	}

	// Update is called once per frame
	void Update () {
		
		transform.Translate (Input.acceleration.x * speed, (Input.acceleration.y + 0.5f) * speed, 0);
		transform.Translate (Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0);

		if (transform.position.y < minY)
			transform.position = new Vector2(transform.position.x, minY);
		if (transform.position.y > maxY)
			transform.position = new Vector2(transform.position.x, maxY);
		if (transform.position.x < minX)
			transform.position = new Vector2(minX, transform.position.y);
		if (transform.position.x > maxX) 
			transform.position = new Vector2(maxX, transform.position.y);

		if (count == x) 
		{
			if(minObj != null)
			minObj.SetActive (true);
			if(maxObj!= null)
			maxObj.SetActive (true);
			GameObject.Find ("Effector").GetComponent<DarkEffect> ().Black (nextScene);
			Camera.main.GetComponent<OpenController> ().Oper ();
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log ("1");
		if(gameObject.name != "Radar")
		{
			for (int i = 0; i < renderer.Length; i++) {
				if (coll.gameObject.name == renderer [i].gameObject.name) {
					renderer [i].gameObject.SetActive (true);
					coll.gameObject.SetActive (false);
					break;
				}
			}
		}
		count++;
	}
}
