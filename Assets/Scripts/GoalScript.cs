using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoalScript : MonoBehaviour
{

    public GameObject WinScreen;
    public Player player;
    public ScoreController scoreController;

    public void playerReachesGoal() 
    {
        Time.timeScale = 0f;
        WinScreen.SetActive(true);
        if (scoreController != null) 
        {
            scoreController.addScore(scoreController.timeScore);
        }
        
    }

    public void OnCollisionEnter2D(Collision2D other) 
    {
        GameObject PlayerObj = other.gameObject;
        Player player = PlayerObj.GetComponent<Player>();
        //if the colliding object has Player tag, deal damage.
        if (other.gameObject.CompareTag("Player"))
        {
            playerReachesGoal();
        }

    }

    public void ResetLevel()
    {   
        WinScreen.SetActive(false);
        player.resetLevel();
    }
}
