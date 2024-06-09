using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMng : MonoBehaviour
{
    private GameMode gm;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI healthText;
    public GameObject _gameover;
    [SerializeField] public Button _restart;
    [SerializeField] public Button _menu;
    public int score = 0;
    private int healthguage = 3;

    private void Start()
    {
        Time.timeScale = 1f;
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        healthText = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
        _restart.onClick.AddListener(RestartGame);
        _menu.onClick.AddListener(BackToIntro);
    }

    private void Update()
    {
        if (healthguage < 1)
        {
            healthText.text = "Health: " + healthguage;
            GameOver();    
        }
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void UpdateHealth(int health)
    {
        healthguage += health;
        healthText.text = "Health: " + healthguage;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        _gameover.gameObject.SetActive(true);
    }
    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void BackToIntro()
    {
        Time.timeScale = 1f;
        gm = GameMode.INTRO;
        SceneManager.LoadScene("IntroScene");
    }
}
