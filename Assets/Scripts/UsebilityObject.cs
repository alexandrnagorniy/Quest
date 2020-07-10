using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsebilityObject : MonoBehaviour {
	public string nameObject;
	private Inventory inv;
	private GameManager manager;
	private DarkEffect effector;
	public bool inactiveMe;
	public bool inactiveCollider;
	public bool unlockObject;
	public GameObject[] unlockedObjects;
	public GameObject unlockedObject;
	public GameObject doubleUnlockedObject;
	public bool parting;
	public int needParts;
	public int haveParts;
	public Sprite sprite;
	public bool move;
	public GameObject moveLocation;
	public bool lockObj;
	public GameObject lockObject;
	public bool addItem;
	public Item item;
    public bool playSound;
    public AudioClip clip;
	private Loader loader;
	public bool playAnimation;
	private Animator animator;

	void Start () 
	{
		if (playAnimation)
			animator = GetComponent<Animator> ();
		loader = GetComponent<Loader> ();
		effector = GameObject.FindGameObjectWithTag("Effector").GetComponent<DarkEffect>();
		manager = Camera.main.GetComponent<GameManager>();
		inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	}

	void LogUnlock(GameObject tmp)
	{
		Camera.main.GetComponent<Testing> ().AddData ("Object " + tmp.name + " unlocked. This object have position: " 
			+ new Vector3( tmp.GetComponent<Loader> ().posData.posX, tmp.GetComponent<Loader> ().posData.posY, tmp.GetComponent<Loader> ().posData.posZ) 
			+ ", scale: " 
			+ new Vector3( tmp.GetComponent<Loader> ().posData.scaleX, tmp.GetComponent<Loader> ().posData.scaleY, tmp.GetComponent<Loader> ().posData.scaleZ)  + ", activity: "
			+  tmp.GetComponent<Loader> ().posData.isActive + ", collider activity: " +  tmp.GetComponent<Loader> ().posData.isCollider);
	}

	void LogUse(GameObject tmp)
	{
		Camera.main.GetComponent<Testing> ().AddData ("In object " + tmp.name + " used " + nameObject + ". This object have position: " 
			+ new Vector3( tmp.GetComponent<Loader> ().posData.posX, tmp.GetComponent<Loader> ().posData.posY, tmp.GetComponent<Loader> ().posData.posZ) 
			+ ", scale: " 
			+ new Vector3( tmp.GetComponent<Loader> ().posData.scaleX, tmp.GetComponent<Loader> ().posData.scaleY, tmp.GetComponent<Loader> ().posData.scaleZ)  + ", activity: "
			+  tmp.GetComponent<Loader> ().posData.isActive + ", collider activity: " +  tmp.GetComponent<Loader> ().posData.isCollider);
	}

	public void Use()
	{
		if (inv.select != null) 
		{
			if (inv.select.gameObject.name == nameObject) 
			{
				inv.Remove ();

				if(lockObj)
					lockObject.SetActive (false);

				if (move)
					GameObject.FindGameObjectWithTag ("Effector").GetComponent<DarkEffect> ().Black (moveLocation);

				if (unlockObject)
				{
					if (unlockedObjects.Length > 0) {
						for (int i = 0; i <= unlockedObjects.Length - 1; i++) 
						{
							unlockedObjects [i].SetActive (true);
							unlockedObjects [i].GetComponent<Loader> ().SavePosition ();
							LogUnlock (unlockedObjects [i]);
						}
					} 
					else
					{
						unlockedObject.SetActive (true);
						unlockedObject.GetComponent<Loader> ().SavePosition ();
						LogUnlock (unlockedObject);
						if (doubleUnlockedObject != null) 
						{
							doubleUnlockedObject.SetActive (true);
							doubleUnlockedObject.GetComponent<Loader> ().SavePosition ();
							LogUnlock (doubleUnlockedObject);
						}
					}
				}
                if (playSound)
                    AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);

				if(inactiveMe)
					gameObject.SetActive (false);
				
				if(inactiveCollider)
					GetComponent<BoxCollider2D>().enabled = false;
				
				if (addItem)
					inv.AddItem (item);

				if (playAnimation)
					animator.SetTrigger ("Photo");

				loader.SavePosition ();
				LogUse (gameObject);
            }	
		}
	}

	void OnMouseDown()
	{		
		Use ();
	}
}