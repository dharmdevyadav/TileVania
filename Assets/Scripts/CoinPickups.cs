using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickups : MonoBehaviour
{
    [SerializeField] AudioClip SFXCoinSound;
    [SerializeField] int PointsToAdd=100;
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(PointsToAdd);
            AudioSource.PlayClipAtPoint(SFXCoinSound, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
