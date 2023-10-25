using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickups : MonoBehaviour
{
    [SerializeField] AudioClip SFXCoinSound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(SFXCoinSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
