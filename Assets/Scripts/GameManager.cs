using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int lives = 3;

    public static GameManager instance;
    public Ball ball;
    public Player player;
    public int bricks = 0;

    // Variable para controlar si el AutoPlay está activado o no
    public bool isAutoPlayEnabled = false;

    public void Awake()
    {
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

    public void LoseLive()
    {
        lives--;

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
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
        if (bricks <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Función para alternar el AutoPlay (activar/desactivar)
    public void ToggleAutoPlay()
    {
        isAutoPlayEnabled = !isAutoPlayEnabled;
    }
}