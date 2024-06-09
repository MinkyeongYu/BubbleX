using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDown : MonoBehaviour
{
    [SerializeField] public bool isBossDown = false;
    [SerializeField] public GameObject finalStage; 
    [SerializeField] public GameObject door;
    private void Update()
    {
        if (isBossDown && finalStage.activeSelf == true)
        {
            door.gameObject.SetActive(false);
        }
    }
}
