using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KoinText : MonoBehaviour
{
    private TextMeshProUGUI koinText;
    void Start()
    {
        koinText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        koinText.text = "Koin:" + GameManager.koin.ToString();
    }
}
