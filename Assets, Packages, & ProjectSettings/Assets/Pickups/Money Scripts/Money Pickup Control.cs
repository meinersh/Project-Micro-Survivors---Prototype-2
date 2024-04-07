using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickupControl : MonoBehaviour
{
    public float Value;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Increase the player's amount of XP
            Game_Control.Player_Money += Value;
            //Deletes itself.
            Destroy(gameObject);
        }
    }
}
