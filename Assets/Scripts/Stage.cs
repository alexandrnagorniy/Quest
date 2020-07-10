using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {
	public GameObject obj;
	private bool opened;
	public bool disableActivation;
	private int stages;
	public int needs;
	void OnMouseDown()
	{
		opened = !opened;
        if (obj != null)
            obj.SetActive(opened);
		if (disableActivation)
			this.enabled = false;
	}

	public void Open()
	{
		opened = !opened;
		obj.SetActive(opened);
	}
	public void AddStage()
	{
		stages++;
		if (stages == needs)
			Open ();
	}
}
