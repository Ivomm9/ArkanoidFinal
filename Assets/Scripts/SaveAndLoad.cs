using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad
{

    
    public void Save(string sceneName) {

        PlayerPrefs.SetInt("score", GameManager.instance.score);
        PlayerPrefs.SetInt("lives", GameManager.instance.lives);
        PlayerPrefs.SetString("scene", sceneName);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        GameManager.instance.score = PlayerPrefs.GetInt("score");
        GameManager.instance.lives = PlayerPrefs.GetInt("lives");
        SceneManager.LoadScene(PlayerPrefs.GetInt("scene"));
    }

}
