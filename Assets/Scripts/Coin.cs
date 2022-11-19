using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static ScoreController scorecontroller;
    static GameObject[] coins; 

    public void CoinCollected()
    {
        gameObject.SetActive(false);
        if(scorecontroller != null) scorecontroller.addRewardScore();
    }
    public static void InitCoins() //This needs to be called in start to save all active coin objects in the game
    {
        scorecontroller = FindObjectOfType<ScoreController>(); // We get ScoreController and save it
        coins = GameObject.FindGameObjectsWithTag("Coin");
    }
    public static void ReactivateAllCoins() // Reactivates all coins
    {
        if (coins != null) //Null checks so tests wont blow up
        {
            foreach (GameObject coin in coins)
            {
                coin.SetActive(true);
            }
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if object has Player tag, add coin reward and deactivate it.
        if (collision.gameObject.CompareTag("Player"))
        {
            CoinCollected();
        }
    }


}
