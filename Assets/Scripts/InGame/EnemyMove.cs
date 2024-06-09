using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour
{
    private GameMng _gameMng;
    private Rigidbody2D rigid;
    public int nextMove;
    public float _health = 5f;
    public int _power = 1;
    private Bubble bubble;
    public string Boss;
    private BossDown _bossDown;
    
    private void Awake()
    {
        _gameMng = GameObject.Find("GameManager").GetComponent<GameMng>();
        _bossDown = GameObject.Find("GameManager").GetComponent<BossDown>();
        rigid = GetComponent<Rigidbody2D>();
        Invoke(nameof(Think), 2f);
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector2.down, 1, LayerMask.GetMask("Ground"));
        if (rayHit.collider == null)
        {
            nextMove *= -1;
            CancelInvoke();
            Invoke(nameof(Think), 2f);
        }
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);

        float nextThinkTime = Random.Range(2f, 5f);
        Invoke(nameof(Think), nextThinkTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            bubble = other.gameObject.GetComponent<Bubble>();
            UpdateEnemyHealth(bubble.power);
            if (_health <= 0)
            {
                if (Boss == "Boss")
                {
                    _bossDown.isBossDown = true;
                }
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameMng.UpdateHealth(-_power);
        }
    }

    void UpdateEnemyHealth(float health)
    {
        _health -= health;
    }
}
