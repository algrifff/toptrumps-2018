using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	#region Publics
	[SerializeField]
	private GameObject player1TextObject;

	[Header("Starting objects")]
	[SerializeField]
	private RotateController rotateController;
	[SerializeField]
	private GameObject readyButton;
	[SerializeField]
	private GameObject rotateRightButton;
	[SerializeField]
	private GameObject rotateLeftButton;

	[Header("Score Fields")]
	[SerializeField]
	private int player1Score;
	[SerializeField]
	private int player2Score;
	[SerializeField]
	private Text player1ScoreText;
	[SerializeField]
	private Text player2ScoreText;

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
	#endregion

	private List<int> Player2Stats = new List<int>();
	private bool player1Win;
	private bool player2Win;


	//events
	public delegate void Player1Card(Card card);
	public static event Player1Card SendCard;
	public delegate void Player2Card(Card card);
	public static event Player2Card SendCard2;

	
	void Start ()
	{
		//readyButton.SetActive(false);
		//buttonCanvas.SetActive(false);
		//player1TextObject.SetActive(false);
		rotateLeftButton.SetActive(false);
		rotateRightButton.SetActive(false);
		rotateController.enabled = true;
		player1Win = true;
		player2Win = false;
		
	}
	IEnumerator RoundStart()
	{
		UpdateScore();
		UpdateCards();
		//round 1 visual cue



		// do this last
		buttonCanvas.SetActive(true);
		return null;
	}
	

	void UpdateCards()
	{
		SendCard(Player1[0]);
		SendCard2(Player2[0]);
		if(player1Win == false)
		{
			buttonCanvas.SetActive(false);
			Player2Turn(); 
		}
		else 
		{
			buttonCanvas.SetActive(true);
		}
		
	}
	

	void UpdateScore()
	{
		player1Score = Player1.Count;
		player2Score = Player2.Count;
		player1ScoreText.text = "" + player1Score;
		player2ScoreText.text = "" + player2Score;
	}

	void Comparison(int player1Comparison, int player2Comparison)
	{
		if (player1Comparison > player2Comparison)
		{
			Card oldCard = Player1[0];

			Player1.Add(Player2[0]);
			Player1.Remove(Player1[0]);
			Player1.Add(oldCard);
			Player2.Remove(Player2[0]);
			player1Win = true;
			player2Win = false;
			UpdateCards();

			UpdateScore();
		}
		else if (player2Comparison > player1Comparison)
		{
			Card oldCard = Player2[0];

			Player2.Add(Player1[0]);
			Player2.Remove(Player2[0]);
			Player2.Add(oldCard);
			Player1.Remove(Player1[0]);
			player1Win = false;
			player2Win = true;
			UpdateCards();

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

			UpdateCards();

			UpdateScore();
		}
		else
		{
			return;
		}
	}
	#region Player 2 Control
	void Player2Turn()
	{
		Player2Stats.Add(Player2[0].pace);
		Player2Stats.Add(Player2[0].dribbling);
		Player2Stats.Add(Player2[0].shooting);
		Player2Stats.Add(Player2[0].defending);
		Player2Stats.Add(Player2[0].passing);
		Player2Stats.Add(Player2[0].strength);

		int statSelected = Player2Stats[Random.Range(0, Player2Stats.Count)];

		//pace stat selected
		if (statSelected == Player2Stats[0])
		{
			OnPaceClick();
		}
		//dribbling stat selected
		if (statSelected == Player2Stats[1])
		{
			OnDribblingClick();
		}
		//shooting stat selected
		if (statSelected == Player2Stats[2])
		{
			OnShootingClick();
		}
		//defending stat selected
		if (statSelected == Player2Stats[3])
		{
			OnDefendingClick();
		}
		//passing stat selected
		if (statSelected == Player2Stats[4])
		{
			OnPassingClick();
		}
		//strength stat selected
		if (statSelected == Player2Stats[5])
		{
			OnStrengthClick();
		}

		for (int i = 0; i < Player2Stats.Count; i++)
		{
			Player2Stats.Remove(Player2Stats[i]);
		}

	}
	#endregion

	#region Button Interactions

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
		for (int i = 0; i < ManCity.Count / 2; i++)
		{
			Player1.Add(ManCity[i]);
		}
		for (int i = ManCity.Count / 2; i < ManCity.Count; i++)
		{
			Player2.Add(ManCity[i]);
		}

		readyButton.SetActive(false);
		rotateLeftButton.SetActive(false);
		rotateRightButton.SetActive(false);
		
		rotateController.enabled = false;

		StartCoroutine(RoundStart());
	}

	//button interactions
	public void OnPaceClick()
	{
		Comparison(Player1[0].pace, Player2[0].pace);
	}
	public void OnDribblingClick()
	{
		Comparison(Player1[0].dribbling, Player2[0].dribbling);
	}
	public void OnShootingClick()
	{
		Comparison(Player1[0].shooting, Player2[0].shooting);
	}
	public void OnDefendingClick()
	{
		Comparison(Player1[0].defending, Player2[0].defending);
	}
	public void OnPassingClick()
	{
		Comparison(Player1[0].passing, Player2[0].passing);
	}
	public void OnStrengthClick()
	{
		Comparison(Player1[0].strength, Player2[0].strength);
	}
	#endregion
}
