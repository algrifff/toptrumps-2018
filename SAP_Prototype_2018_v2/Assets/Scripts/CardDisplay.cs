using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public Card currentCard;

	[SerializeField]
	private Text nameText;
	[SerializeField]
	private Text positionText;

	//text fields for stat name changes
	[Header("Titles Text Fields")]
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

	// text fiels for number changes
	[Header("Statistic Text Fields")]
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
		GameManager.SendCard += RecieveCard;
	}

	private void OnDisable()
	{
		GameManager.SendCard -= RecieveCard;
	}

	// Use this for initialization
	void Start () {
		
	}

	void RecieveCard(Card card)
	{
		currentCard = card;

		nameText.text = "" + card.name;
		positionText.text = "" + card.position;
		paceIntText.text = "" + card.pace;
		dribblingIntText.text = "" + card.dribbling;
		shootingIntText.text = "" + card.shooting;
		defendingIntText.text = "" + card.defending;
		passingIntText.text = "" + card.passing;
		strengthIntText.text = "" + card.strength;

		if(card.position == "GK")
		{
			paceText.text = "Diving";
			dribblingText.text = "Handling";
			shootingText.text = "Kicking";
			defendingText.text = "Reflexes";
			passingText.text = "Speed";
			strengthText.text = "Positioning";
		}
		else
		{
			paceText.text = "Pace";
			dribblingText.text = "Dribbling";
			shootingText.text = "Shooting";
			defendingText.text = "Defending";
			passingText.text = "Passing";
			strengthText.text = "Strength";
		}

	}
	
	
}
