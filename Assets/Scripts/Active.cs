using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour {

    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] GameObject _activeGO;
    bool detect;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool activeBool = _sprite.bounds.Contains(mousePos);
        if(Input.GetMouseButtonDown(0) && activeBool && !detect)
        {
            _activeGO.SetActive(true);
            Invoke("Delay", 0.5f);
        }

        if(_activeGO.activeInHierarchy && detect)
        {    
            if(Input.GetMouseButtonDown(0))
            {
                _activeGO.SetActive(false);
                detect = false;
            }    
        }
	}

    void Delay()
    {
        detect = true;
    }
}
