using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    private BallController ball;
    private bool gameActive;
    public Text livesText;
    public int lives;
    public GameObject gameOverScreen;
    public GameObject PauseScreen;
    public GameObject levelWin;
    public int score;
    public Text scoreText;
    public Text HighScoreText;
    private int currentHighScore;
    //gameActive weather game start
    void Start () {
        ball = FindObjectOfType<BallController>();
        score = PlayerPrefs.GetInt("currentScore");
        lives= PlayerPrefs.GetInt("currentLives");
        livesText.text = "LIVES:" + lives;
        scoreText.text = "SCORE: " + score;
        currentHighScore = PlayerPrefs.GetInt("HighScore");
        HighScoreText.text = "HIGHSCORE:" + currentHighScore;
        Time.timeScale = 1f;
    }
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)&& !gameActive)
        {
            ball.ActivateBall();
            gameActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseScreen.activeSelf)
            {
                PauseScreen.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                PauseScreen.SetActive(true);
                //Time.timeScale = 0 stop the time
                Time.timeScale = 0;
                
            }
        }
        var brickCheck = FindObjectOfType<BrickController>();
        if(brickCheck == null)
        {
            levelWin.SetActive(true);
            Time.timeScale = 0;
            PlayerPrefs.SetInt("currentScore", score);
            PlayerPrefs.SetInt("HighScore", currentHighScore);
        }
	}
    public void RespawnBall()
    {
        gameActive = false;
        lives = lives - 1;
        if (lives == -1)
        {
            ball.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            livesText.text = "ALL LIVES LOST";
            PlayerPrefs.SetInt("HighScore", currentHighScore);
        }
        else
        {
            livesText.text = "LIVES:" + lives;
        }
        PlayerPrefs.SetInt("currentLives", lives);
    }
    public void Addscore(int ScoreToAdd)
    {
        score = score + ScoreToAdd;
        scoreText.text = "SCORE: " + score;
        if (score > currentHighScore)
        {
            currentHighScore = score;
            HighScoreText.text = "HIGHSCORE:" + currentHighScore;
        }
    }
   
}
