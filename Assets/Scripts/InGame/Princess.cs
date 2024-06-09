using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Princess : MonoBehaviour
{
    private GameMode gm;
    public GameObject Congrats;
    [SerializeField] public Button _restart;
    [SerializeField] public Button _menu;
    // [SerializeField] public GameObject Stage1;
    // [SerializeField] public GameObject Stage2;
    // [SerializeField] public GameObject FinalStage;


    private void Start()
    {
        _restart.onClick.AddListener(RestartGame);
        _menu.onClick.AddListener(BackToIntro);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("congrats");
            Congrats.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
        // Stage1.gameObject.SetActive(true);
        // Stage2.gameObject.SetActive(false);
        // FinalStage.gameObject.SetActive(false);
        
    }

    void BackToIntro()
    {
        Time.timeScale = 1f;
        gm = GameMode.INTRO;
        SceneManager.LoadScene("IntroScene");
    }
}
