using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasOilController : MonoBehaviour
{
	public Sprite sprite;
    [SerializeField] SpriteRenderer[] _sprite;
    int count;
	public GameObject nextScene;

	void Update ()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool sprite1 = _sprite[0].bounds.Contains(mousePos);
        if (Input.GetMouseButtonDown(0) && sprite1 && count == 0)
        {
            count++;
        }
        bool sprite2 = _sprite[1].bounds.Contains(mousePos);
        if (Input.GetMouseButtonDown(0) && sprite2 && count == 1)
        {
            count++;
        }
        bool sprite3 = _sprite[2].bounds.Contains(mousePos);
        if (Input.GetMouseButtonDown(0) && sprite3 && count == 2)
        {
            count++;
        }
        bool sprite4 = _sprite[3].bounds.Contains(mousePos);
        if (Input.GetMouseButtonDown(0) && sprite4 && count == 3)
        {
            count++;
        }

        if(count == 4)
        {
            GetComponent<CircleManager>().Enter();
        }

    }
}
