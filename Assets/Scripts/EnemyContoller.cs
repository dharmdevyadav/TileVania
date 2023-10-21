using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D enemyrigidbody;
    //BoxCollider2D wallbreak;
    //Animator flipbody;
    //Vector2 moveInput;
    void Start()
    {
        enemyrigidbody = GetComponent<Rigidbody2D>();
        //wallbreak = GetComponent<BoxCollider2D>();
        //flipbody = GetComponent<Animator>();
    }


    void Update()
    {
        enemyrigidbody.velocity = new Vector2(moveSpeed, 0f);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyBody();
    }

    void FlipEnemyBody()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyrigidbody.velocity.x)), 1f);
    }
}
