using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private CircleCollider2D _bubbleCollider2D;
    private Rigidbody2D _bubbleRigid;
    private float _bubbleSpeed = 10f;
    private float distance;
    public LayerMask isLayer;
    private Player _player;
    private Vector2 _direction;
    public float power;
    
    private void Awake()
    {
        _bubbleCollider2D = GetComponent<CircleCollider2D>();
        _bubbleRigid = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Invoke(nameof(DestroyBubble), 3f);
    }

    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider != null)
        {
            Destroy(gameObject);
        }
        transform.Translate(_direction * (_bubbleSpeed * Time.deltaTime));
    }

    void DestroyBubble()
    {
        Destroy(gameObject);
    }
    

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
    }
}
