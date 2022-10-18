using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    private void DealDamage(Player playerObject)
    {
        playerObject.health = 0;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
  
        //if the colliding object has Player tag, deal damage.
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject PlayerObj = other.gameObject;
            Player player = PlayerObj.GetComponent<Player>();
            DealDamage(player);
        }
       

    }
}
