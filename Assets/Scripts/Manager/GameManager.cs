using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

	public int score;
	int bestScore;

	void Awake()
	{
		if(instance == null)
			instance = this;
	}

	void Start()
	{
		Init();
	}

	void Update()
	{
		SaveBestScore();
	}

	void Init()
	{
		Time.timeScale = 1;
		GUIManager.instance.ShowGameGUI(false);
		bestScore = PlayerPrefs.GetInt("BestScore");
		GUIManager.instance.UpdateBestScoreText(bestScore);
	}

	public void PLayGame()
	{
		Time.timeScale = 1;
		GUIManager.instance.ShowGameGUI(true);
		SpawnManager.instance.Spawn();
	}

	public void PauseGame(bool isShow)
	{
		if(isShow)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;

		GUIManager.instance.ShowPanel("Pause", isShow);
	}

	public void EndGame()
	{
		Time.timeScale = 0;
		GUIManager.instance.ShowPanel("Game", false);
		GUIManager.instance.ShowPanel("Over", true);
	}

	public void ResetGame()
	{
		SceneManager.LoadScene(0);
	}

	void SaveBestScore()
	{
		bestScore = PlayerPrefs.GetInt("BestScore");
		if (score > PlayerPrefs.GetInt("BestScore"))
		{
			PlayerPrefs.SetInt("BestScore", score);
		}
	}
}
