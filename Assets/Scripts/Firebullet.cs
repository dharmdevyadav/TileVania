using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebullet : MonoBehaviour
{
    [SerializeField] float Speed = 20f;
    Rigidbody2D bulletbody;
    PlayerController Player;
    float xSpeed;
    void Start()
    {
        bulletbody=GetComponent<Rigidbody2D>();
        Player = FindObjectOfType<PlayerController>();
        xSpeed = Player.transform.localScale.x * Speed;

    }
    
    
    void Update()
    {
        bulletbody.velocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        //Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
