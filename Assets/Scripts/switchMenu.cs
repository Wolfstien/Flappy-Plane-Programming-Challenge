using UnityEngine;
using UnityEngine.SceneManagement;

public class switchMenu {

	public void goToMenu ()
	{
		//shortest class eva!
		SceneManager.LoadScene ("menu", LoadSceneMode.Single);
	}
}
