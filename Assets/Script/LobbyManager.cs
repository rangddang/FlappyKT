using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
	public Image image;
	public List<Sprite> skins = new List<Sprite>();

	private void Start()
	{
		image.sprite = image.sprite = skins[GameManager.skin];
	}

	public void GameStart()
	{
		GameManager.gameOver = false;
		GameManager.score = 0;
		SceneManager.LoadScene("FlappyGame");
	}

	public void GoToSkin()
	{
		SceneManager.LoadScene("SkinTap");
	}

	public void Exit()
	{
		Application.Quit();
	}
}
