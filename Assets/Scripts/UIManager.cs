using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highscoreText;
    [SerializeField] TMP_Text livesText;

    void Start()
    {
        GameManager.instance.scoreText = scoreText;
        GameManager.instance.highscoreText = highscoreText;
        GameManager.instance.livesText = livesText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
