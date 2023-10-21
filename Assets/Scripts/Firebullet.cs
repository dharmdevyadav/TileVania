using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebullet : MonoBehaviour
{
    [SerializeField] float Speed = 10f;
    Rigidbody2D bulletbody;
    void Start()
    {
        bulletbody=GetComponent<Rigidbody2D>();

    }

    
    void Update()
    {
        bulletbody.velocity = new Vector2(Speed, 0f);
    }
}
