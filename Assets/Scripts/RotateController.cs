using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour {

	[SerializeField]
	private GameObject gameBoard;
	[SerializeField]
	private int rotation;

	private bool rotateRightActive;
	private bool rotateLeftActive;

	// Update is called once per frame
	void Update () {
		
		if(rotateRightActive == true && rotateLeftActive == false)
		{
			
			gameBoard.transform.Rotate(new Vector3(0, -rotation * Time.deltaTime, 0), Space.Self);
			//rotate object positively
		}
		if (rotateLeftActive == true && rotateRightActive == false)
		{
			
			gameBoard.transform.Rotate(new Vector3(0, rotation * Time.deltaTime, 0), Space.Self);
			//rotate object negatively
		}
		if (rotateLeftActive == true && rotateRightActive == true)
		{
			return;
		}

	}

	public void OnRotateRightDown()
	{		
		rotateRightActive = true;
	}
	public void OnRotateRightUp()
	{
		rotateRightActive = false;
	}
	public void OnRotateLeftDown()
	{
		rotateLeftActive = true;
	}
	public void OnRotateLeftUp()
	{
		rotateLeftActive = false;
	}

}
