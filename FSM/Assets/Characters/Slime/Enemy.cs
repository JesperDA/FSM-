using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public DectectionZone dectectionZone;
    public float moveSpeed = 500f;
    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (dectectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (dectectionZone.detectedObjs[0].transform.position - transform.position).normalized;


            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
    }
    public float Health
    {
        set
        {
            _health = value;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
        get
        {
            return _health;
        }
    }

    public float _health = 1;

    void OnHit(float damage)
    {
        Health -= damage;
    }

    public void Defeated()
    {
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

}
