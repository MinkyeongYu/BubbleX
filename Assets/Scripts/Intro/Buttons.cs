using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameMode
{
    INTRO,
    GUIDE,
    STORY,
    INGAME,
}

public class Buttons : MonoBehaviour
{
    public Button _start;
    public Button _howToplay;
    public Button _story;
    public Button _back;
    public Button _quit;
    public Image storyImg;
    public Image howToPlayImg;
    private GameMode gm;

    private void Start()
    {
        _start.onClick.AddListener(StartGame); 
        _howToplay.onClick.AddListener(HowToPlay);
        _story.onClick.AddListener(LoadStory);
        _back.onClick.AddListener(GoBack);
        _quit.onClick.AddListener(QuitApp);
        gm = GameMode.INTRO;
    }

    private void Update()
    {
        Debug.Log(gm);
    }

    void StartGame()
    {
        gm = GameMode.INGAME;
        SceneManager.LoadScene("GameScene");
    }

    void HowToPlay()
    {
        howToPlayImg.gameObject.SetActive(true);
        _back.gameObject.SetActive(true);
        gm = GameMode.GUIDE;
    }

    void LoadStory()
    {
        _back.gameObject.SetActive(true);
        storyImg.gameObject.SetActive(true);
        gm = GameMode.STORY;
    }

    void GoBack()
    {
        _back.gameObject.SetActive(false);
        if (gm == GameMode.GUIDE)
        {
            howToPlayImg.gameObject.SetActive(false);
        }
        else if (gm == GameMode.STORY)
        {
            storyImg.gameObject.SetActive(false);
        }
        gm = GameMode.INTRO;
    }

    void QuitApp()
    {
        Application.Quit();
    }
}
