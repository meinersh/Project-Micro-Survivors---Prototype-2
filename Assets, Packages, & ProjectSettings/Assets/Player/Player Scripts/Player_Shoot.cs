//Causes the player to shoot projectiles when input is recieved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    //Bullet Spawn points from the player
    public Transform bulletSpawnPoint0; //Up
    public Transform bulletSpawnPoint90; //Right
    public Transform bulletSpawnPoint180; //Down
    public Transform bulletSpawnPoint270; //Left

    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public float Base_Cooldown;

    private float Time_Till_Next_Shot;

    // Update is called once per frame
    void Update()
    {
        float fire = Input.GetAxisRaw("Fire1");
        Time_Till_Next_Shot -= Time.deltaTime;
        //Makes sure the game is not paused
        if (Game_Control.GamePaused == false)
        {
            if (fire >= 0.1)
            {
                if (Time_Till_Next_Shot <= 0)
                {
                    //Creates a bullet at the bullet spawn point assigned. Stores it as variable so it can be edited when spawned
                    var bullet = Instantiate(bulletPrefab, bulletSpawnPoint0.position, bulletSpawnPoint0.rotation);
                    //Sets the bullet velocity so it goes in the correct direction
                    bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint0.up * bulletSpeed;

                    var bullet2 = Instantiate(bulletPrefab, bulletSpawnPoint90.position, bulletSpawnPoint90.rotation);
                    bullet2.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint90.right * bulletSpeed;

                    var bullet3 = Instantiate(bulletPrefab, bulletSpawnPoint180.position, bulletSpawnPoint180.rotation);
                    bullet3.GetComponent<Rigidbody2D>().velocity = -bulletSpawnPoint180.up * bulletSpeed;

                    var bullet4 = Instantiate(bulletPrefab, bulletSpawnPoint270.position, bulletSpawnPoint270.rotation);
                    bullet4.GetComponent<Rigidbody2D>().velocity = -bulletSpawnPoint270.right * bulletSpeed;

                    StartWeaponCoolDown();
                }
            }
        }
        
    }
    private void StartWeaponCoolDown()
    {
        Time_Till_Next_Shot = Base_Cooldown / Game_Control.Player_Attack_Speed;
    }
}