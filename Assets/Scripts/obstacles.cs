using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour {

	private Rigidbody2D rb;
	// Use this for initialization
	void Start () 
	{
		//get obstacles and apply static x velocity <--    Obstacles: "lets crush that plane!"
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (GameControl.instance.scrollSpeed, 0);
	}

	private void OnTriggerEnter2D(Collider2D obj)
	{
		//score trigger     Obstacles: "dammit, he slithered right thru me!"
		if(obj.GetComponent<plane>()!=null)
		{
			GameControl.instance.scored ();
		}
	}
}

