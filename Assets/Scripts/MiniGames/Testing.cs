using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {
	public TestingData data;

	public void Load()
	{
		data = JsonUtility.FromJson<TestingData> (PlayerPrefs.GetString ("TestAllGame"));
	}

	public void AddData(string tmp)
	{
		data.step.Add (System.DateTime.Now.ToString () + " : " + tmp);
		PlayerPrefs.SetString ("TestAllGame", JsonUtility.ToJson(data));
	}
}

[System.Serializable]
public class TestingData
{
	public List<string> step = new List<string>();
}