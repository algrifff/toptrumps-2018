using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public static SceneController Instance;

	private void OnEnable()
	{
		ButtonManager.
	}
	private void OnDisable()
	{
		
	}
	void Start()
	{
		if (Instance != null)
		{
			GameObject.Destroy(gameObject);
		}
		else
		{
			GameObject.DontDestroyOnLoad(gameObject);
			Instance = this;
		}
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
