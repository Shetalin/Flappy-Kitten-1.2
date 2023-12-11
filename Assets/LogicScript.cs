using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource plusScoreSound;
    public AudioSource gameOverSound;
    public AudioSource gameOverMusic;
    public AudioSource onButtonSound;
    public AudioSource rumblingSound;
    public CatScript catScript;

    void Start()
    {
        catScript = GameObject.Find("Cat").GetComponent<CatScript>();
    }

    public void addScore(int scoreToAdd)
    {
        if (gameOverScreen.activeSelf == false)
        {
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();
            plusScoreSound.Play();
            highScoreText.text = $"best: {PlayerPrefs.GetInt("HighScore", 0)}";
        }

    }

    public void checkHighScore()
    {
        if(playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game restarted");
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void gameOver()
    {
        if(!gameOverScreen.activeSelf)
        {
            gameOverScreen.SetActive(true);
            Debug.Log("Game over screen on");
            catScript.activeMusic.Pause();
            gameOverSound.Play();
            gameOverMusic.Play();
        }
        
    }

    private void Update()
    {
        if (gameOverScreen.activeSelf && Input.GetKeyDown(KeyCode.Space) == true)
        {
            restartGame();
        }
    }

    public void onButton()
    {
        onButtonSound.Play();
    }

}
