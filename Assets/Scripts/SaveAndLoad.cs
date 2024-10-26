using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    
    public void Save() {

        PlayerPrefs.SetInt("score", GameManager.instance.score);
        PlayerPrefs.SetInt("lives", GameManager.instance.lives);
        PlayerPrefs.SetInt("scene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        GameManager.instance.score = PlayerPrefs.GetInt("score");
        GameManager.instance.lives = PlayerPrefs.GetInt("lives");
        SceneManager.LoadScene(PlayerPrefs.GetInt("scene"));
    }

}
