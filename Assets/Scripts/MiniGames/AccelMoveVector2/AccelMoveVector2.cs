using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelMoveVector2 : MonoBehaviour {
	public AccelMoveVector2Manager manager;
	public float speed;
	public float minX, maxX, minY, maxY;
	float x, y;
	public Animator anim;
    public ActiveObjectFromCamera aoc;

	void Start()
	{
		anim = GetComponent <Animator> ();
		//anim.enabled = false;
	}

	void Update()
	{
		x = Input.acceleration.x;
		y = Input.acceleration.y + 0.5f;
		transform.Translate (new Vector3 (x, y, 0));

		if (transform.localPosition.x < minX)
			transform.localPosition = new Vector3 (minX, transform.localPosition.y, 2);
		else if (transform.localPosition.x > maxX)
			transform.localPosition = new Vector3 (maxX, transform.localPosition.y, 2);
		if (transform.localPosition.y < minY)
			transform.localPosition = new Vector3 (transform.localPosition.x, minY, 2);
		else if (transform.localPosition.y > maxY)
			transform.localPosition = new Vector3 (transform.localPosition.x, maxY, 2);
	}
		
	public IEnumerator Enter()
	{
		yield return new WaitForSeconds (2);
		manager.Enter ();
	}
}
