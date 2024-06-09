using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private GameObject player;
    public GameObject this_stage;
    public GameObject next_stage;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Arrived");
            player.transform.position = new Vector2(-8, -1);
            this_stage.gameObject.SetActive(false);
            next_stage.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
