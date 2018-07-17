using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private GameObject readyButton;

	[Header("Team being used")]
	[SerializeField]
	private List <Card> ManCity;

	[Header("Players teams")]
	[SerializeField]
	private List<Card> Player1;
	[SerializeField]
	private List<Card> Player2;

	[Header("Player button interactions")]
	[SerializeField]
	private GameObject paceButton;
	[SerializeField]
	private GameObject dribblingButton;
	[SerializeField]
	private GameObject shootingButton;
	[SerializeField]
	private GameObject defendingButton;
	[SerializeField]
	private GameObject passingButton;
	[SerializeField]
	private GameObject strengthButton;


	public delegate void Player1Card(Card card);
	public static event Player1Card SendCard;

	// Use this for initialization
	void Start ()
	{
		//readyButton.SetActive(false);
		
	}

	public void OnReadyClicked()
	{
		//on button click start game shuffling
		for (int i = 0; i < ManCity.Count; i++)
		{
			Card temp = ManCity[i];
			int randomIndex = Random.Range(i, ManCity.Count);
			ManCity[i] = ManCity[randomIndex];
			ManCity[randomIndex] = temp;
		}
		for(int i = 0; i < ManCity.Count/2; i++)
		{
			Player1.Add(ManCity[i]);
		}
		for (int i = ManCity.Count / 2; i < ManCity.Count; i++)
		{
			Player2.Add(ManCity[i]);
		}
		readyButton.SetActive(false);
		SendToPlayer1();
		SendToPlayer2();
	}

	void SendToPlayer1()
	{
		SendCard(Player1[0]);
	}
	void SendToPlayer2()
	{
		
	}

	//button interactions
	public void OnPaceClick()
	{

	}
	public void OnDribblingClick()
	{

	}
	public void OnShootingClick()
	{

	}
	public void OnDefendingClick()
	{

	}
	public void OnPassingClick()
	{

	}
	public void OnStrengthClick()
	{

	}
}
