using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour {

	public float boost = 350f;

	public Sprite greenPlane, redPlane;
	public GameObject planeObj;

	private SpriteRenderer sr;
	private Animator planeAnim;

	private bool playerAlive=true;
	private Rigidbody2D rb;
	private float angle = 0f;

	// Use this for initialization

	void Awake()
	{
		//reference to animator ... to select red or green plane animation based on user preference from the main menu.
		planeAnim = planeObj.GetComponent<Animator> ();
		planeAnim.SetBool ("green", false);
		planeAnim.SetBool ("red", false);
		sr = planeObj.GetComponent<SpriteRenderer>(); 
		if (PlayerPrefs.GetString ("currentPlane")=="redPlane") 
		{
			sr.sprite = redPlane;
			planeAnim.SetBool ("red", true);
		}
		else if (PlayerPrefs.GetString ("currentPlane")=="greenPlane") 
		{
			sr.sprite = greenPlane;
			planeAnim.SetBool ("green", true);
		}
	}

	void Start () 
	{
		//ever seen a non-rigid plane? duh!
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//plane alive!
		if(playerAlive)
		{
			//jump boost and manually set jump rotation angle
			//Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Began   .... easy copy paste for when testing on pc lol.
			if (Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Began) 
			{
				rb.velocity = Vector2.zero;
				rb.AddForce (new Vector2 (0, boost));
				angle = 60f;
				rb.MoveRotation (angle);
			}

			//manually rotate angle towards velocity direction
			if(angle>-70f)
			{
				rb.MoveRotation (angle);
				angle-=1.5f;
			}
		}
	}

	//drive more carefully next time!
	void OnCollisionEnter2D()
	{
		//R.I.P
		GameControl.instance.onPlayerDeath ();
	}
}
