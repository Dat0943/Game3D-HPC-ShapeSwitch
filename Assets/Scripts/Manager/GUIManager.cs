using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
	public static GUIManager instance;

	[SerializeField] private GameObject homeGUI;
	[SerializeField] private GameObject gameGUI;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject gameoverPanel;
	[SerializeField] private TMP_Text scoreText;
	[SerializeField] private TMP_Text scoreEndText;
	[SerializeField] private TMP_Text bestScoreText;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public void ShowGameGUI(bool isShow)
	{
		if (gameGUI != null)
			gameGUI.SetActive(isShow);

		if (homeGUI != null)
			homeGUI.SetActive(!isShow);
	}

	public void ShowPanel(string panel, bool isShow)
	{
		if(panel == "Pause")
		{
			pausePanel.SetActive(isShow);
		}
		else if(panel == "Over")
		{
			gameoverPanel.SetActive(isShow);
		}
		else if (panel == "Game")
		{
			gameGUI.SetActive(isShow);
		}
	}

	public void UpdateScoreText(int score)
	{
		if (scoreText != null)
			scoreText.text = score.ToString();

		if (scoreText != null)
			scoreEndText.text = score.ToString();
	}

	public void UpdateBestScoreText(int score)
	{
		if (scoreText != null)
			bestScoreText.text = score.ToString();
	}
}
