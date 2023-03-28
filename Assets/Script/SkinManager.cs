using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;
	public int selectedSkin = 0;
	public List<Sprite> skins = new List<Sprite>();

	private void Start()
	{
		selectedSkin = GameManager.skin;
		spriteRenderer.sprite = skins[selectedSkin];
	}

	public void NextOption()
	{
		selectedSkin++;
		if(selectedSkin >= skins.Count)
		{
			selectedSkin = 0;
		}
		spriteRenderer.sprite = skins[selectedSkin];
	}

	public void BackOption()
	{
		selectedSkin--;
		if (selectedSkin < 0)
		{
			selectedSkin = skins.Count - 1;
		}
		spriteRenderer.sprite = skins[selectedSkin];
	}

	public void Click()
	{
		GameManager.skin = selectedSkin;
		PlayerPrefs.SetInt("Skin", GameManager.skin);
	}


	public void GoTotLobby()
	{
		SceneManager.LoadScene("Lobby");
	}
}
