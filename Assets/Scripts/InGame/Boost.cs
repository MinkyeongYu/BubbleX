using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Boost : MonoBehaviour
{
    private GameMng _gameMng;
    public GameObject _reward;
    public List<Button> _options;
    private Player _player;

    private void Start()
    {
        _gameMng = GameObject.Find("GameManager").GetComponent<GameMng>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (_gameMng.score > 3)
            {
                _reward.gameObject.SetActive(true);
                _options[0].onClick.AddListener(SelectRewardAsHeal);
                _options[1].onClick.AddListener(SelectRewardAsPower);
                _options[2].onClick.AddListener(SelectRewardAsJump);
                _options[3].onClick.AddListener(SelectRewardAsCoolDownBubble);
            }
            
        }
    }

    void SelectRewardAsHeal()
    {
        _gameMng.UpdateHealth(1);
        _reward.gameObject.SetActive(false);
        _gameMng.UpdateScore(-3);
        Destroy(gameObject);
    }
    void SelectRewardAsPower()
    {
        _player.UpdatePower(1f);
        _reward.gameObject.SetActive(false);
        _gameMng.UpdateScore(-3);
        Destroy(gameObject);
    }
    void SelectRewardAsJump()
    {
        _player._jumpheight += 3f;
        _reward.gameObject.SetActive(false);
        _gameMng.UpdateScore(-3);
        Destroy(gameObject);
    }
    void SelectRewardAsCoolDownBubble()
    {
        _player._cooltime -= 0.2f;
        _reward.gameObject.SetActive(false);
        _gameMng.UpdateScore(-3);
        Destroy(gameObject);
    }
}
