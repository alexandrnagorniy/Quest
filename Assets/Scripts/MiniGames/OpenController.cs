using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenController : MonoBehaviour {
	public int count;
	public int max;
	public GameObject[] go;

	public void Oper()
	{
		count++;
		if (count == max)
			for (int i = 0; i < go.Length; i++) {
				go [i].SetActive (true);
			}
	}
}
