using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Last : MonoBehaviour {
	public int count;
	public int max;

	public void Oper()
	{
		count++;
		if (count == max)
			SceneManager.LoadScene ("Final");
	}
}
