using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VictoryScreen : MonoBehaviour {
    public Text playerScore;
	// Use this for initialization
	void Start () {
        playerScore.text = PlayerPrefs.GetInt("currentScore")+" "+"points";
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainMenu");
        }
	}
}
