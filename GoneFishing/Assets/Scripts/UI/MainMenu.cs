using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
	{
		Cursor.visible = false;
		SceneManager.LoadScene("Level");
	}

	public void Options()
	{

	}

	public void QuitGame()
	{
		Application.Quit();
	}

	
}
