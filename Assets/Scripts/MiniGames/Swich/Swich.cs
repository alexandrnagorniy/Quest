using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swich : MonoBehaviour {
	public Sprite[] sprites;
	private bool isActive;
	private SpriteRenderer renderer;
	public SwichManager manager;
    public AudioClip clip;

	void OnMouseDown()
	{
        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        isActive = !isActive;
		transform.Rotate (0, 0, 180);
		if (isActive)
			manager.Switch (1);
		else
			manager.Switch (-1);
	}
}
