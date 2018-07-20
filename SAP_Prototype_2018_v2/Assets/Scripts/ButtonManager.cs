using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	[SerializeField]
	private GameObject mainMenu;
	[SerializeField]
	private GameObject topTrumpsMenu;
	[SerializeField]
	private GameObject t_hostJoinMenu;
	[SerializeField]
	private GameObject t_teamSelectMenu;
	[SerializeField]
	private GameObject drillsMenu;

	public delegate void SceneChange(string sceneName);
	public static event SceneChange NewScene;
	
	private void Start()
	{
		mainMenu.SetActive(true);

		topTrumpsMenu.SetActive(false);
		t_teamSelectMenu.SetActive(false);
		t_teamSelectMenu.SetActive(false);
		drillsMenu.SetActive(false);
		
		
	}

	public void OnTopTrumpsClick()
	{
		mainMenu.SetActive(false);
		topTrumpsMenu.SetActive(true);
		t_hostJoinMenu.SetActive(true);
		t_teamSelectMenu.SetActive(false);
		
	}
	public void OnDrillsClick()
	{
		mainMenu.SetActive(false);
		drillsMenu.SetActive(true);
		
	}

	public void OnHostClick()
	{
		t_hostJoinMenu.SetActive(false);
		t_teamSelectMenu.SetActive(true);
		
	}

	//top trumps team selection
	public void OnTopTrumpsTeamSelectClick()
	{
		//load top trump scene (pass the scene to load to the scene manager)
		Debug.Log("load top trumps scene");
		NewScene("TopTrumps");
	}

	public void OnDrillsSelectClick()
	{
		//load drill scene (pass scene to load to scene manager)
		Debug.Log("load drills scene");
		NewScene("Drills");
	}


	public void OnTopTrumpsHostBackButtonClick()
	{
		mainMenu.SetActive(true);
		topTrumpsMenu.SetActive(false);
		
	}
	public void TopTrumpsTeamScreenBackButton()
	{
		t_teamSelectMenu.SetActive(false);
		t_hostJoinMenu.SetActive(true);
	}
	public void OnDrillsTeamChooseBackClick()
	{
		mainMenu.SetActive(true);
		drillsMenu.SetActive(false);

	}
}
