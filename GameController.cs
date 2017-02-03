using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
	public Text[] buttonList;
	private string playerSide;
	public GameObject gameOverPanel;
	public Text gameOverText;
	private int moveCount;
	public GameObject restartButton;
	void Awake()
	{
		SetGameControllerReferenceOnButtons ();
		playerSide = "X";
		gameOverPanel.SetActive (false);
		moveCount = 0;
		restartButton.SetActive (false);
	}

	void SetGameControllerReferenceOnButtons()
	{
		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList [i].GetComponentInParent<GridSpace> ().SetGameControllerReference (this);
		}
	}

	public string GetPlayerSide()
	{
		return playerSide;
	}

	public void EndTurn()
	{
		CheckForWin ();
		ChangeSides ();
		moveCount++;
		if (moveCount >= 9) 
		{
			gameOverPanel.SetActive (true);
			gameOverText.text = "It's A Draw!";
			restartButton.SetActive (true);
		}
	}
	private void CheckForWin()
	{
		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) 
		{
			GameOver();
		}
		if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide) 
		{
			GameOver();
		}
		if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide) 
		{
			GameOver();
		}
		if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide) 
		{
			GameOver();
		}
		if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide) 
		{
			GameOver();
		}
		if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide) 
		{
			GameOver();
		}
		if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide) 
		{
			GameOver();
		}
		if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide) 
		{
			GameOver();
		}
	}

	private void GameOver()
	{
		for(int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<Button>().interactable = false;
		}
		gameOverPanel.SetActive (true);
		gameOverText.text = playerSide + " Wins!";
		moveCount = 0;
		restartButton.SetActive (true);
	}

	private void ChangeSides()
	{
		playerSide = (playerSide == "X") ? "O" : "X";
	}

	public void RestartGame()
	{
		playerSide = "X";
		moveCount = 0;
		gameOverPanel.SetActive (false);
		for(int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<Button>().interactable = true;
			buttonList [i].text = " ";
		}
		restartButton.SetActive (false);
	}
}
