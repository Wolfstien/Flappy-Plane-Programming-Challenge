using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public bool reloadGame = false;
	public float scrollSpeed = - 3f;

	private int currentScore = 0;
	private int bestScore = 0;

	public Text scoreText;
	public Text bestText;

	// Use this for initialization
	void Awake()
	{
		//too many cooks spoil the soup!
		if (instance == null) {
			instance = this;
		}
		else if (instance!=this)
		{
			Destroy (gameObject);
		}
	}

	void Start () 
	{
		//store best score in user preferences (quick and dirty, will find a better way later).
		if (PlayerPrefs.GetInt("bestScore") != null) {
			bestScore = PlayerPrefs.GetInt ("bestScore");
			bestText.text = "Best : " + bestScore.ToString ();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if plane collision/player death, reload active scene i.e. main gameLoop.
		if(reloadGame==true)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}

	//your lucky this is a game and not real life! you get a re-do.
	public void onPlayerDeath()
	{
		reloadGame = true;
	}

	//for people with short-term memory loss, to keep track of their score.
	public void scored()
	{
		currentScore++;
		scoreText.text = "Score : " + currentScore.ToString ();
		if (bestScore<currentScore) 
		{
			bestScore = currentScore;
			bestText.text = "Best : " + bestScore.ToString ();
			PlayerPrefs.SetInt ("bestScore", bestScore);
		}
	}
	// Author: Adrian Pereira
}
