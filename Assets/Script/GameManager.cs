using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public static int koin = 0;
	public static int skin = 0;
	public static bool gameOver = false;
    public GameObject gameOverPanel;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Setting()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
        else
    	{
            PlayerPrefs.SetInt("Score", -1);
    	}
		if (PlayerPrefs.HasKey("Koin"))
		{
            koin = PlayerPrefs.GetInt("Koin");
        }
		else
		{
            PlayerPrefs.SetInt("Koin", 0);
        }
		if (PlayerPrefs.HasKey("Skin"))
		{
			skin = PlayerPrefs.GetInt("Skin");
		}
		else
		{
			PlayerPrefs.SetInt("Skin", 0);
		}
	}

	private void Start()
    {
        gameOver = false;
        score = 0;
    }

    private void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            UpdateScore();
            UpdateKoin();

		}
        else
        {
            gameOverPanel.SetActive(false);
        }
    }
    
    public void UpdateScore()
    {
        if (PlayerPrefs.GetInt("Score") < 0)
    	{
            PlayerPrefs.SetInt("Score", score);
            return;
    	}
    
        if (score > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
        }
    }

    public void UpdateKoin()
	{
        PlayerPrefs.SetInt("Koin", koin);
    }
    
    public void ReStart()
    {
        gameOver = false;
        score = 0;
        SceneManager.LoadScene("FlappyGame");
    }
    
    public void GoTotLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
