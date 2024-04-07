//This Script Manages The Enemy's stats like health and damage.
//Detects when it collides with the player and then lowers their health.
//Detects when it's health is below 0 spawns XP and then deletes itself.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    //Enemy Stats
    public float Enemy_damage;
    public float Enemy_health;

    public GameObject XP_Pickup;
    public GameObject Money_Pickup;

    private void Awake()
    {
        Enemy_health += (Game_Control.Player_Level / 5);
    }

    // Update is called once per frame
    void Update()
    {
        //If health is less than or equal to zero
        if(Enemy_health <= 0)
        {
            //Increase the amount of kills this game
            Game_Control.Game_Kills++;

            //Creates an XP pick up where the enemy died.
            Instantiate(XP_Pickup, gameObject.transform.position, gameObject.transform.rotation);
            //Creates a Money Pick up only 50% of the time.
            int _temp_value = Random.Range(1, 100);
            if(_temp_value >= 10 / Game_Control.Player_Luck)
            {
                Instantiate(Money_Pickup, gameObject.transform.position, gameObject.transform.rotation);
            }
            //Deletes itself
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player Collision
        if (collision.gameObject.CompareTag("Player"))
        {
            //Lowers the player's health by the enemies damage
            Game_Control.Player_Health -= Enemy_damage;
        }
    }
}
