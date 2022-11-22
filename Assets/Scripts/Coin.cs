using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static ScoreController scoreController;
    public static GameObject CoinPickupEffect;
    static GameObject[] coins;
    public static AudioManager audioManager;

    private static int coinSound = 1;

    public void CoinCollected()
    {
        if(CoinPickupEffect != null) CreateCoinPickupEffect();
        gameObject.SetActive(false);
        if(scoreController != null) scoreController.addRewardScore();

        if (audioManager != null)
        {
            // Cycle through 3 different coin sounds when collecting a coin.
            audioManager.Play("coin_" + coinSound);
            if (coinSound == 3)
            {
                coinSound = 1;
            }
            else { coinSound++; }

        }
    }
    public static void InitCoins() //This needs to be called in start to save all active coin objects in the game
    {
        scoreController = FindObjectOfType<ScoreController>(); // We get ScoreController and save it
        audioManager = FindObjectOfType<AudioManager>(); // We get AudioManager and save it 
        coins = GameObject.FindGameObjectsWithTag("Coin");
        CoinPickupEffect = Resources.Load("Prefabs/CoinPickupEffect", typeof(GameObject)) as GameObject;
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

    void CreateCoinPickupEffect() 
    {
        GameObject puff = Instantiate(CoinPickupEffect);
        puff.transform.position = transform.position;
        if(Application.isPlaying) Destroy(puff, 1); //Check that we are not in edit mode (EditModeTests)
    }

}
