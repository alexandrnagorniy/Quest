using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour {
	public float speed;
	public float minX, maxX, minY, maxY;
	float x, y;
	// Use this for initialization
	void Start () {
		
	}

	void Update()
	{
		transform.Translate(new Vector3(x, y, 0));

		if (transform.localPosition.x < minX)
			transform.localPosition = new Vector3 (minX, transform.localPosition.y, 2);
		else if (transform.localPosition.x > maxX)
			transform.localPosition = new Vector3 (maxX, transform.localPosition.y, 2);
		if (transform.localPosition.y < minY)
			transform.localPosition = new Vector3 (transform.localPosition.x, minY, 2);
		else if (transform.localPosition.y > maxY)
			transform.localPosition = new Vector3 (transform.localPosition.x, maxY, 2);
	}

	// Update is called once per frame
	/*void OnMouseDrag () 
	{
		if (transform.position.x <= maxX && transform.position.x >= minX)
			x = transform.position.x + Input.GetAxis ("Mouse X") * 2;
		else if (transform.position.x > maxX)
			x = maxX;
		else if (transform.position.x < minX)
			x = minX;
		
		if (transform.position.y <= maxY && transform.position.y >= minY)
			y = transform.position.y + Input.GetAxis ("Mouse Y") * 2 * Time.deltaTime;
		else if (transform.position.y > maxY)
			y = maxY;
		else if (transform.position.y < minY)
			y = minY;
			transform.position = new Vector3 (x, y, -9);
	}*/

	void OnMouseDrag()
	{
        Debug.Log("but");
		x = Input.GetAxis ("Mouse X") / speed;
		y = Input.GetAxis ("Mouse Y") / speed;

	}
    void OnMouseUp()
    {
        x = 0;
        y = 0;
    }

}