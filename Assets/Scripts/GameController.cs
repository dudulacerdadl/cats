using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;
    public AudioSource gameOverSound;
    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        AudioController.instance.BackgroundSoundPause();
        gameOverSound.Play();
        gameOver.SetActive(true);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("initialMenu");
    }

    public void Iniciar()
    {
        SceneManager.LoadScene("lvl_1");
    }

    public void ShowPause(GameObject pause)
    {
        pause.SetActive(true);
    }

    public void HidePause(GameObject pause)
    {
        pause.SetActive(false);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
