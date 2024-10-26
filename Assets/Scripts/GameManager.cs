using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int lives = 3;

    public static GameManager instance;
    public Ball ball;
    public Player player;
    public int bricks = 0;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text livesText;

    public SaveAndLoad saveLoad;

    public int score = 0;
    public int highscore = 0;

    // Variable para controlar si el AutoPlay está activado o no
    public bool isAutoPlayEnabled = false;

    public void Awake()
    {
        saveLoad = new SaveAndLoad();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void Start()
    {
       // scoreText.text = score.ToString();
      //  highscoreText.text = "Best: " + highscore.ToString();
    }

    public void LoseLive()
    {
        lives--;

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            livesText.text = "Lives:" + lives.ToString();
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        ball.ResetBall();
        player.ResetPlayer();
    }

    public void CheckLevelCompleted()
    {
        if (bricks <= 0 && SceneManager.GetActiveScene().name == "Level1")
        {
            saveLoad.Save("Level2");
            SceneManager.LoadScene("Level2");
        }
        else if (bricks <= 0 && SceneManager.GetActiveScene().name == "Level2")
        {
            saveLoad.Save("Level1");
            SceneManager.LoadScene("Level1");
        }
    }

    // Función para alternar el AutoPlay (activar/desactivar)
    public void ToggleAutoPlay()
    {
        isAutoPlayEnabled = !isAutoPlayEnabled;
    }

    public void AddPoints(Brick brick)
    {
        score += 10;
        scoreText.text = score.ToString();

        if (highscore <= score)
        {
            highscore = score;
            highscoreText.text = highscore.ToString();
            PlayerPrefs.SetInt("highscore", highscore);
        }

    }
}