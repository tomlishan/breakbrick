using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public string firstLevel;
	// Use this for initialization
	public void Newgame()
    {
        SceneManager.LoadScene(firstLevel);
        PlayerPrefs.SetInt("currentScore",0);
        PlayerPrefs.SetInt("currentLives", 3);
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
