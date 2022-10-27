using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoalScript : MonoBehaviour
{

    public GameObject WinScreen;
    public Player player;

    public void playerReachesGoal() 
    {
        Time.timeScale = 0f;
        WinScreen.SetActive(true);
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

    public void ResetPlayerPosition()
    {   
        Time.timeScale = 1f;
        player.transform.position = new Vector3(0, 0, 0);
        WinScreen.SetActive(false);
    }
}
