using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class switchPlane : MonoBehaviour {

	public Sprite greenPlane, redPlane;
	public Button switchBtn;
	public GameObject plane;
	private SpriteRenderer sr;
	//private bool startLoop = false;

	// Use this for initialization
	void Awake () 
	{
		//set plance color sprite based on selected user settings.
		sr = plane.GetComponent<SpriteRenderer>(); 
		if (PlayerPrefs.GetString ("currentPlane")=="redPlane") 
		{
			sr.sprite = redPlane;
		}
		else if (PlayerPrefs.GetString ("currentPlane")=="greenPlane") 
		{
			sr.sprite = greenPlane;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if screen tapped && and the tap is not over a game object, switch/start scene/game.
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			EventSystem eventSystem = EventSystem.current;
			if (eventSystem.IsPointerOverGameObject (Input.GetTouch(0).fingerId)) {
				Debug.Log ("true");
			} else {
				Debug.Log ("false");
				SceneManager.LoadScene ("gameLoop", LoadSceneMode.Single);
			}
		}
	}

	public void planeChange()
	{
		//do you prefere RED or GREEN?
		if (sr.sprite==greenPlane) 
		{
			sr.sprite = redPlane;
			PlayerPrefs.SetString ("currentPlane","redPlane");
		} 
		else if(sr.sprite==redPlane) 
		{
			sr.sprite = greenPlane;
			PlayerPrefs.SetString ("currentPlane","greenPlane");
		}
	}
}
