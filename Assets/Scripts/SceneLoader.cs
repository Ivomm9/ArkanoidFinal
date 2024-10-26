using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Canvas pauseCanvas;
    public GameObject continueButton;

    private void Start()
    {
        if (PlayerPrefs.GetInt("score") == 0 && SceneManager.GetActiveScene().name == "MainMenu")
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
    }
    public void LostGame()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("lives", 3);
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        GameManager.instance.highscore = PlayerPrefs.GetInt("highscore");
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("lives", 3);
        SceneManager.LoadScene("Level1");
    }

    public void ContinueGame()
    {
        GameManager.instance.highscore = PlayerPrefs.GetInt("highscore");
        GameManager.instance.saveLoad.Load();
    }

}
