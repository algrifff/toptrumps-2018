using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Controller : MonoBehaviour {

	public Card currentCard;

	[SerializeField]
	private Text nameText;
	[SerializeField]
	private Text positionText;

	//text fields for 3d stat name changes
	[Header("Titles Text Fields for 3D")]
	[SerializeField]
	private Text paceText;
	[SerializeField]
	private Text dribblingText;
	[SerializeField]
	private Text shootingText;
	[SerializeField]
	private Text defendingText;
	[SerializeField]
	private Text passingText;
	[SerializeField]
	private Text strengthText;

	// text fields for 3d number changes
	[Header("Statistics for Text Fields for 3D")]
	[SerializeField]
	private Text paceIntText;
	[SerializeField]
	private Text dribblingIntText;
	[SerializeField]
	private Text shootingIntText;
	[SerializeField]
	private Text defendingIntText;
	[SerializeField]
	private Text passingIntText;
	[SerializeField]
	private Text strengthIntText;

	private void OnEnable()
	{
		GameManager.SendCard2 += RecieveCard;
	}

	private void OnDisable()
	{
		GameManager.SendCard2 -= RecieveCard;
	}

	// Use this for initialization
	void Start()
	{

	}

	void RecieveCard(Card card)
	{
		currentCard = card;
		//sets 3D object values
		nameText.text = "" + card.name;
		positionText.text = "Position: " + card.position;
		paceIntText.text = "" + card.pace;
		dribblingIntText.text = "" + card.dribbling;
		shootingIntText.text = "" + card.shooting;
		defendingIntText.text = "" + card.defending;
		passingIntText.text = "" + card.passing;
		strengthIntText.text = "" + card.strength;

		if (card.position == "GK")
		{
			//3D text
			paceText.text = "Diving";
			dribblingText.text = "Handling";
			shootingText.text = "Kicking";
			defendingText.text = "Reflexes";
			passingText.text = "Speed";
			strengthText.text = "Positioning";
		}

		else
		{
			//3D text
			paceText.text = "Pace";
			dribblingText.text = "Dribbling";
			shootingText.text = "Shooting";
			defendingText.text = "Defending";
			passingText.text = "Passing";
			strengthText.text = "Strength";

		}

	}
}

