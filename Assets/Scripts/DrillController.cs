using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.HelloAR;

public class DrillController : MonoBehaviour {

	[SerializeField]
	private GameObject playButton;
	[SerializeField]
	private GameObject pauseButton;
	[SerializeField]
	private GameObject pauseMenuButton;
	[SerializeField]
	private GameObject pauseMenu;

	[SerializeField]
	private Animator soccerPlayerAnimator;
	[SerializeField]
	private Animator ballAnimator;


	private bool loop;

	private void OnEnable()
	{
		HelloARController.OnDrillStart += OnDrillStart;
	}
	private void OnDisable()
	{
		HelloARController.OnDrillStart -= OnDrillStart;
	}
	// Use this for initialization
	void Start ()
	{
		playButton.SetActive(false);
		pauseButton.SetActive(false);

	}
	
	IEnumerator PlayClicked()
	{
		playButton.SetActive(false);
		pauseButton.SetActive(true);
		Time.timeScale = 1;
		soccerPlayerAnimator.SetBool("start", true);
		ballAnimator.SetBool("start", true);
		yield return new WaitForSeconds(1);
		soccerPlayerAnimator.SetBool("start", false);
		ballAnimator.SetBool("start", false);
		yield return new WaitForSeconds(8);
		if (loop == true)
		{
			StartCoroutine(PlayClicked());
		}
		else
		{
			yield return null;
		}
	}

	void OnDrillStart()
	{
		playButton.SetActive(true);
		pauseButton.SetActive(false);
	}
	
	public void OnPlayClick()
	{
		loop = true;
		StartCoroutine(PlayClicked());
		
	}
	public void OnPauseClick()
	{
		playButton.SetActive(true);
		pauseButton.SetActive(false);

		Time.timeScale = 0;
	}

	public void OnPauseMenuClick()
	{
		pauseMenuButton.SetActive(false);
		pauseMenu.SetActive(true);
		playButton.SetActive(false);
		pauseButton.SetActive(false);
	}

	
}
