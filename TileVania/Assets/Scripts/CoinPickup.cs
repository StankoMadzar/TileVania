using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag == "Player" && !wasCollected)
      { 
        wasCollected = true;
        //PlayClipAtPoint means that the sound won't stop when the gameObject is destroyed
        AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position/*volume can be added as a third parameter of type float*/);
        FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
        gameObject.SetActive(false);
        Destroy(gameObject);
      }  
    }
}
