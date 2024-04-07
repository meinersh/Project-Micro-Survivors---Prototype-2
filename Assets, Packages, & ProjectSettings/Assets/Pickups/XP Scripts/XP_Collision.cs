//The XP pickup should only collide with the player.
//After colliding with a player it will increase the player's xp by a certain amount and then destroy itself.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_Collision : MonoBehaviour
{
    public int XP_Amount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            //Increase the player's amount of XP
            Game_Control.Player_XP += XP_Amount;
            //Deletes itself.
            Destroy(gameObject);
        }
    }
}
