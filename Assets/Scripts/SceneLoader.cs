using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject continueButton;

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ContinueGame()
    {
        if (PlayerPrefs.GetInt("score") == 0)
        {
            continueButton.SetActive(false);
        }

        GameManager.instance.saveLoad.Load();
    }
}
