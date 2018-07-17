using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[Header("Score Fields")]
	[SerializeField]
	private int player1Score;
	[SerializeField]
	private int player2Score;
	[SerializeField]
	private Text player1ScoreText;
	[SerializeField]
	private Text player2ScoreText;

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
	private GameObject buttonCanvas;
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

	private int player1Comparison;
	private int player2Comparison;

	// Use this for initialization
	void Start ()
	{
		readyButton.SetActive(false);
		buttonCanvas.SetActive(false);
		
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
		buttonCanvas.SetActive(true);

		UpdateScore();

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

	void UpdateScore()
	{
		player1Score = Player1.Count;
		player2Score = Player2.Count;
		player1ScoreText.text = "" + player1Score;
		player2ScoreText.text = "" + player2Score;
	}

	void Comparison()
	{
		if (player1Comparison > player2Comparison)
		{
			Card oldCard = Player1[0];

			Player1.Add(Player2[0]);
			Player1.Remove(Player1[0]);
			Player1.Add(oldCard);
			Player2.Remove(Player2[0]);
			SendToPlayer1();

			UpdateScore();
		}
		else if (player2Comparison > player1Comparison)
		{
			Card oldCard = Player2[0];

			Player2.Add(Player1[0]);
			Player2.Remove(Player2[0]);
			Player2.Add(oldCard);
			Player1.Remove(Player1[0]);
			SendToPlayer1();

			UpdateScore();
		}
		else if (player1Comparison == player2Comparison)
		{
			Card oldCard1 = Player1[0];
			Card oldCard2 = Player2[0];

			Player1.Remove(Player1[0]);
			Player2.Remove(Player2[0]);
			Player1.Add(oldCard1);
			Player2.Add(oldCard2);

			UpdateScore();
		}
	}

	#region Button Interactions
	//button interactions
	public void OnPaceClick()
	{
		player1Comparison = Player1[0].pace;
		player2Comparison = Player2[0].pace;

		Comparison();
	}
	public void OnDribblingClick()
	{
		player1Comparison = Player1[0].dribbling;
		player2Comparison = Player2[0].dribbling;

		Comparison();
	}
	public void OnShootingClick()
	{
		player1Comparison = Player1[0].shooting;
		player2Comparison = Player2[0].shooting;

		Comparison();
	}
	public void OnDefendingClick()
	{
		player1Comparison = Player1[0].defending;
		player2Comparison = Player2[0].defending;

		Comparison();
	}
	public void OnPassingClick()
	{
		player1Comparison = Player1[0].passing;
		player2Comparison = Player2[0].passing;

		Comparison();
	}
	public void OnStrengthClick()
	{
		player1Comparison = Player1[0].strength;
		player2Comparison = Player2[0].strength;

		Comparison();
	}
	#endregion
}
