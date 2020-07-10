using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	public Manager manager;
	public int i;
	public bool sprite;
	private SpriteRenderer renderer;
    public AudioClip clip;

	void Start()
	{
		if(sprite)
		renderer = GetComponent<SpriteRenderer> ();
	}

	void OnMouseDown()
	{
        if(clip != null)
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
		if (renderer != null)
			renderer.color = Color.white;
        manager.PushButton (i);
	}
}