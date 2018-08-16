using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

	[SerializeField]
	private GameObject buttonCanvas;
	[SerializeField]
	private GameObject pauseButton;
	[SerializeField]
	private GameObject pauseMenu;

	private bool wasActive;

	public delegate void LoadScene(string scene);
	public static event LoadScene MainMenuClicked;

	public void OnPauseClicked()
	{
		//activate pause menu here
		if (buttonCanvas.activeInHierarchy)
		{
			buttonCanvas.SetActive(false);
			wasActive = true;
		}
		pauseButton.SetActive(false);
		pauseMenu.SetActive(true);
		Time.timeScale = 0;
	}
	public void OnResumeClicked()
	{
		//deactivate pause menu here
		if(wasActive == true)
		{
			buttonCanvas.SetActive(true);
			wasActive = false;
		}
		pauseButton.SetActive(true);
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
	}
	public void OnHomeClicked()
	{
		//load scene 
		MainMenuClicked("MainMenu");
	}
	public void OnPlayAgainClicked()
	{
		MainMenuClicked("TopTrumps");
	}
}
