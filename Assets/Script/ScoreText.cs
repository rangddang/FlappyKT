using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI bestScoreText;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        bestScoreText = GameObject.Find("BestScore").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = GameManager.score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("Score") > 0 ? PlayerPrefs.GetInt("Score").ToString() : "0";
    }
}
