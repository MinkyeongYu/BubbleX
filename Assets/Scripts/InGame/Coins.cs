using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int _value;
    private GameMng _gameMng;
    
    private void Start()
    {
        _gameMng = GameObject.Find("GameManager").GetComponent<GameMng>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
            _gameMng.UpdateScore(_value);
        }
    }
}
