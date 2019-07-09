using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	#region Setables
	[SerializeField]
	private GameObject player1TextObject;

	[Header("Player Objects")]
	[SerializeField]
	private GameObject player1;
	[SerializeField]
	private GameObject player2;
	[SerializeField]
	private GameObject player1Ui;
	[SerializeField]
	private GameObject player2Ui;

	[Header("Player Model materials")]
	[SerializeField]
	private Material face;
	[SerializeField]
	private Material body;
	[SerializeField]
	private Material hair;
	[SerializeField]
	private Material shoes;
	[SerializeField]
	private Material uniform;
	[SerializeField]
	private Material hiddenPlayer;

	[Header("Player2 model")]
	[SerializeField]
	private GameObject player2Model;
	[SerializeField]
	private GameObject p2CardCover;

	[Header("Starting objects")]
	[SerializeField]
	private RotateController rotateController;
	[SerializeField]
	private GameObject readyButton;
	[SerializeField]
	private GameObject rotateRightButton;
	[SerializeField]
	private GameObject rotateLeftButton;

	[Header("Animators")]
	[SerializeField]
	private Animator player1Animator;
	[SerializeField]
	private Animator player2Animator;

	[Header("Player effects")]
	[SerializeField]
	private GameObject player1Confetti;
	[SerializeField]
	private GameObject player2Confetti;

	[Header("Score Fields")]
	[SerializeField]
	private int player1Score;
	[SerializeField]
	private int player2Score;
	[SerializeField]
	private Text player1ScoreText;
	[SerializeField]
	private Text player2ScoreText;

	[Header("Comparison Fields")]
	[SerializeField]
	private GameObject comparisonUI;
	[SerializeField]
	private Text comparisonStatName;
	[SerializeField]
	private Text comparisonP1Stat;
	[SerializeField]
	private Text comparisonP2Stat;
	private string comparisonName;

	[Header("Win/Lose fields")]
	[SerializeField]
	private GameObject winLoseObject;
	[SerializeField]
	private Text winLoseMainText;
	[SerializeField]
	private GameObject winsText;
	[SerializeField]
	private GameObject drawObject;

	[Header("Round fields")]
	[SerializeField]
	private GameObject roundUi;
	[SerializeField]
	private Text roundNumberText;
	[SerializeField]
	private Text roundInfoText;
	private int roundNum;

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
	[SerializeField]
	private GameObject waitingForPlayer2;

	[Header("EndGame")]
	[SerializeField]
	private Text endgameText;
	[SerializeField]
	private GameObject endgameObject;
	[SerializeField]
	private GameObject pauseButton;
	#endregion

	public List<int> Player2Stats;
	private bool player1Win;
	private bool player2Win;
	private bool draw;


	//events
	public delegate void Player1Card(Card card);
	public static event Player1Card SendCard;
	public delegate void Player2Card(Card card);
	public static event Player2Card SendCard2;

	
	void Start ()
	{
		readyButton.SetActive(false);
		buttonCanvas.SetActive(false);
		player1TextObject.SetActive(false);
		rotateLeftButton.SetActive(false);
		rotateRightButton.SetActive(false);
		player1Confetti.SetActive(false);
		player2Confetti.SetActive(false);
		rotateController.enabled = true;
		player1Win = true;
		player2Win = false;
		
	}
	void Player1Win()
	{
		endgameText.text = "Congratulations!";
		endgameObject.SetActive(true);
		pauseButton.SetActive(false);
		buttonCanvas.SetActive(false);
	}
	void Player2Win()
	{
		endgameText.text = "Try Again!";
		endgameObject.SetActive(true);
		pauseButton.SetActive(false);
		buttonCanvas.SetActive(false);
		
	}
	IEnumerator RoundStart()
	{
		player1Ui.SetActive(false);
		player2Ui.SetActive(false);
		p2CardCover.SetActive(true);
		SendCard(Player1[0]);
		SendCard2(Player2[0]);
		UpdateScore();
		roundNum = roundNum + 1;

		//player1 turn start
		if(player1Win == true)
		{
			roundNumberText.text = "ROUND " + roundNum;
			roundInfoText.text = "PLAYER 1 STARTS!";
			roundUi.SetActive(true);
			yield return new WaitForSeconds(4);
			roundUi.SetActive(false);
			player1Ui.SetActive(true);
			player2Ui.SetActive(true);
			player1TextObject.SetActive(true);
			buttonCanvas.SetActive(true);

		}
		//player 2 turn start
		else if(player1Win == false)
		{
			roundNumberText.text = "ROUND " + roundNum;
			roundInfoText.text = "PLAYER 2 STARTS!";
			roundUi.SetActive(true);
			yield return new WaitForSeconds(4);
			roundUi.SetActive(false);
			player1TextObject.SetActive(true);
			player1Ui.SetActive(true);
			player2Ui.SetActive(true);
			buttonCanvas.SetActive(false);
			waitingForPlayer2.SetActive(true);
			yield return new WaitForSeconds(4);
			waitingForPlayer2.SetActive(false);
			Player2Turn();
		}
		
		yield return null;
	}
	
	IEnumerator RoundEnd()
	{
		p2CardCover.SetActive(false);
		yield return new WaitForSeconds(2);
		player1Ui.SetActive(false);
		player2Ui.SetActive(false);
		comparisonUI.SetActive(true);
		yield return new WaitForSeconds(3);
		comparisonUI.SetActive(false);
		if (draw == false)
		{
			if (player1Win == true)
			{
				player1Confetti.SetActive(true);
				player1Animator.SetBool("Win", true);
				player2Animator.SetBool("Lose", true);
				winLoseMainText.text = "PLAYER 1";
				winsText.SetActive(true);
				winLoseObject.SetActive(true);
				
			}
			else if (player1Win == false)
			{
				player2Confetti.SetActive(true);
				player1Animator.SetBool("Lose", true);
				player2Animator.SetBool("Win", true);
				winLoseMainText.text = "PLAYER 2";
				winsText.SetActive(true);
				winLoseObject.SetActive(true);
				
			}
		}
		else if(draw == true)
		{
			drawObject.SetActive(true);
		}
		yield return new WaitForSeconds(6);

		player1Confetti.SetActive(false);
		player2Confetti.SetActive(false);

		player1Animator.SetBool("Win", false);
		player1Animator.SetBool("Lose", false);

		player2Animator.SetBool("Win", false);
		player2Animator.SetBool("Lose", false);

		winsText.SetActive(false);
		drawObject.SetActive(false);
		winLoseObject.SetActive(false);
		comparisonUI.SetActive(false);

		draw = false;

		UpdateScore();
		StartCoroutine(RoundStart());
		yield return null;
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
		comparisonP1Stat.text = "" + player1Comparison;
		comparisonP2Stat.text = "" + player2Comparison;
		comparisonStatName.text = comparisonName;
		buttonCanvas.SetActive(false);
		if (player1Comparison > player2Comparison)
		{
			Card oldCard = Player1[0];

			Player1.Add(Player2[0]);
			Player1.Remove(Player1[0]);
			Player1.Add(oldCard);
			Player2.Remove(Player2[0]);
			player1Win = true;
			player2Win = false;

			StartCoroutine(RoundEnd());
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

			StartCoroutine(RoundEnd());			
		}
		else if (player1Comparison == player2Comparison)
		{
			Card oldCard1 = Player1[0];
			Card oldCard2 = Player2[0];

			Player1.Remove(Player1[0]);
			Player2.Remove(Player2[0]);
			Player1.Add(oldCard1);
			Player2.Add(oldCard2);
			draw = true;
			StartCoroutine(RoundEnd());
		}
		else
		{
			return;
		}
	}
	#region Player 2 Control
	void Player2Turn()
	{
		Player2Stats = new List<int>();

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
		comparisonName = "PACE";
		Comparison(Player1[0].pace, Player2[0].pace);
		
	}
	public void OnDribblingClick()
	{
		comparisonName = "DRIBBLING";
		Comparison(Player1[0].dribbling, Player2[0].dribbling);
		
	}
	public void OnShootingClick()
	{
		comparisonName = "SHOOTING";
		Comparison(Player1[0].shooting, Player2[0].shooting);
		
	}
	public void OnDefendingClick()
	{
		comparisonName = "DEFENDING";
		Comparison(Player1[0].defending, Player2[0].defending);
		
	}
	public void OnPassingClick()
	{
		comparisonName = "PASSING";
		Comparison(Player1[0].passing, Player2[0].passing);
		
	}
	public void OnStrengthClick()
	{
		comparisonName = "STRENGTH";
		Comparison(Player1[0].strength, Player2[0].strength);
		
	}
	#endregion
}
