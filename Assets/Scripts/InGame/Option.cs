using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Button _optionBtn;
    public Button _resume;
    public Button _restart;
    public Button _menu;
    public GameObject _options;
    private GameMode gm;
    
    private void Start()
    {
        _optionBtn.onClick.AddListener(OpenOptions);
        _resume.onClick.AddListener(ResumeGame);
        _restart.onClick.AddListener(RestartGame);
        _menu.onClick.AddListener(BackToIntro);
    }

    void OpenOptions()
    {
        Time.timeScale = 0f;
        _options.gameObject.SetActive(true);
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
        _options.gameObject.SetActive(false);
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
