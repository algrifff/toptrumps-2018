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

	[Header("Titles for text fields 2D buttons")]
	[SerializeField]
	private Text paceButtonText;
	[SerializeField]
	private Text dribblingButtonText;
	[SerializeField]
	private Text shootingButtonText;
	[SerializeField]
	private Text defendingButtonText;
	[SerializeField]
	private Text passingButtonText;
	[SerializeField]
	private Text strengthButtonText;

	[Header("Statistics for text fields 2D buttons")]
	[SerializeField]
	private Text paceButtonStatText;
	[SerializeField]
	private Text dribblingButtonStatText;
	[SerializeField]
	private Text shootingButtonStatText;
	[SerializeField]
	private Text defendingButtonStatText;
	[SerializeField]
	private Text passingButtonStatText;
	[SerializeField]
	private Text strengthButtonStatText;

	private void OnEnable()
	{
		GameManager.SendCard += RecieveCard;
	}

	private void OnDisable()
	{
		GameManager.SendCard -= RecieveCard;
	}

	// Use this for initialization
	void Start ()
	{
		
	}

	void RecieveCard(Card card)
	{
		currentCard = card;
		//sets 3D object values
		nameText.text = "" + card.name;
		positionText.text = "" + card.position;
		paceIntText.text = "" + card.pace;
		dribblingIntText.text = "" + card.dribbling;
		shootingIntText.text = "" + card.shooting;
		defendingIntText.text = "" + card.defending;
		passingIntText.text = "" + card.passing;
		strengthIntText.text = "" + card.strength;

		//sets 2D menu object values
		paceButtonStatText.text = "" + card.pace;
		dribblingButtonStatText.text = "" + card.dribbling;
		shootingButtonStatText.text = "" + card.shooting;		
		defendingButtonStatText.text = "" + card.defending;		
		passingButtonStatText.text = "" + card.passing;
		strengthButtonStatText.text = "" + card.strength;

		if (card.position == "GK")
		{
			//3D text
			paceText.text = "Diving";
			dribblingText.text = "Handling";
			shootingText.text = "Kicking";
			defendingText.text = "Reflexes";
			passingText.text = "Speed";
			strengthText.text = "Positioning";

			//2D text
			paceButtonText.text = "Diving";
			dribblingButtonText.text = "Handling";
			shootingButtonText.text = "Kicking";
			defendingButtonText.text = "Reflexes";
			passingButtonText.text = "Speed";
			strengthButtonText.text = "Positioning";
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

			//2D text
			paceButtonText.text = "Pace";
			dribblingButtonText.text = "Dribbling";
			shootingButtonText.text = "Shooting";
			defendingButtonText.text = "Defending";
			passingButtonText.text = "Passing";
			strengthButtonText.text = "Strength";
		}

	}
	
	
}
