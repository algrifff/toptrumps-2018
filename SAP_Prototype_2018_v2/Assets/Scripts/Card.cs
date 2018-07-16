using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {


	public new string name;
	public string position;

	public GameObject model;

	public int pace;
	public int dribbling;
	public int shooting;
	public int defending;
	public int passing;
	public int strength;
	



}
