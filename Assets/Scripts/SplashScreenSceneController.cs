using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenSceneController : MonoBehaviour {

	[SerializeField]
	private float time;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(SceneSwitch());
	}
	
	IEnumerator SceneSwitch()
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(1);
	}
}
