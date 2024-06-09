using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameMng _gameMng;
    private float _horizontalInput;
    private float _maxspeed = 3f;
    public float _jumpheight = 6f;
    private Rigidbody2D rigid;

    [SerializeField] private LayerMask _groundLayer;
    private CapsuleCollider2D _capsuleCollider2D;
    private bool _isGrounded = true;
    private Vector3 _footPosition;

    public bool facingRight = true;
    public GameObject bubble;
    public Transform _bubblePosRight;
    public Transform _bubblePosLeft;
    public float _cooltime = 1f;
    private float _curtime;
    private float _power = 2;
    
    private void Awake()
    {
        _gameMng = GameObject.Find("GameManager").GetComponent<GameMng>();
        rigid = GetComponent<Rigidbody2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rigid.AddForce(Vector2.up * _jumpheight, ForceMode2D.Impulse);
            _isGrounded = false;
        }

        if (_horizontalInput < 0)
        {
            facingRight = false;
        }
        else if (_horizontalInput > 0)
        {
            facingRight = true;
        }
        if (_curtime <= 0)
        {
            if (Input.GetMouseButtonDown(1) )
            {
                if (facingRight)
                {
                    GameObject tmpObj = Instantiate(bubble, _bubblePosRight.position, transform.rotation);
                    tmpObj.transform.parent = gameObject.transform;
                    Bubble _bubbleScript = tmpObj.GetComponent<Bubble>();
                    _bubbleScript.SetDirection(facingRight ? Vector2.right : Vector2.left);
                    _bubbleScript.power = _power;
                }
                else
                {
                    GameObject tmpObj = Instantiate(bubble, _bubblePosLeft.position, transform.rotation);
                    tmpObj.transform.parent = gameObject.transform;
                    Bubble _bubbleScript = tmpObj.GetComponent<Bubble>();
                    _bubbleScript.SetDirection(facingRight ? Vector2.right : Vector2.left);
                    _bubbleScript.power = _power;
                }
                _curtime = _cooltime;
            }
        }
        _curtime -= Time.deltaTime;
        
    }

    // a, d 이동
    private void FixedUpdate()
    {
        if (transform.position.y < -20)
        {
            _gameMng.GameOver();
        }
        
        Bounds bounds = _capsuleCollider2D.bounds;
        _footPosition = new Vector2(bounds.center.x, bounds.min.y);
        _isGrounded = Physics2D.OverlapCircle(_footPosition, 0.1f, _groundLayer);
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * (_horizontalInput), ForceMode2D.Impulse);
        if (rigid.velocity.x > _maxspeed)
        {
            rigid.velocity = new Vector2(_maxspeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < -_maxspeed)
        {
            rigid.velocity = new Vector2(-_maxspeed, rigid.velocity.y);
        }
    }
    public void UpdatePower(float power)
    {
        _power += power;
    }
}
