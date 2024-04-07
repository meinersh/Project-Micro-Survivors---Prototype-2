//Controls the Bullets stats and behaviors

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using TMPro;

public class Bullet : MonoBehaviour
{
    //Gets the Player Object for reference;
    public GameObject Player;

    //Creates the Damage number pop ups
    public GameObject Damage_Pop_Up;

    //Base Bullet Stats
    public float Base_Bullet_Damage;
    public float Base_Bullet_Size;
    public float Base_Bullet_Duration;
    private bool canBounce;
    private int maxBounces;

    //Final Bullet Stats
    private float Bullet_Damage;
    private float Bullet_Size;
    private float Bullet_Duration; //How long the bullet last before despawning naturally in seconds

    //Bullet Bounce Variables
    private int currentBounces = 0; //Should always start at 0

    public bool canPierce; //This is here because I think it would be cool but... I am not sure how to implement it.

    //Runs once at the when the bullet is created
    private void Start()
    {
        //Debug.Log("Bullet Spawned");

        //Turns Off collision between the bullet other player bullets
        Physics2D.IgnoreLayerCollision(7, 7, true);

        //Truns Off collision between the bullet and the player
        Physics2D.IgnoreLayerCollision(7, 3, true);

        //Truns Off collision between the bullet and enemy bullets
        Physics2D.IgnoreLayerCollision(7, 8, true);

        Bullet_Damage = Base_Bullet_Damage * Game_Control.Player_Attack_Damage;
        Bullet_Size = Base_Bullet_Size * Game_Control.Player_Attack_Size;

        gameObject.transform.localScale = new Vector3(Bullet_Size, Bullet_Size, Bullet_Size); //Stores the Bullet size into a vecotr3 so it can be used for the scale

        canBounce = Game_Control.Projectile_Bounce;
        maxBounces = Game_Control.Max_Projectile_Bounce_Level + 2;
    }


    private void Awake()
    {
        Bullet_Duration = Base_Bullet_Duration * Game_Control.Player_Projectile_Duration;
        //Destroys Self after the amount second life is set to.
        Destroy(gameObject, Bullet_Duration);
    }

    private void Update()
    {
        transform.Rotate(0, 0, 3);
    }

    //Runs when the object collides with another collider.
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Wall Collision
        if (collision.gameObject.CompareTag("Wall") && canBounce != true)
        {
            Destroy(gameObject);
        }

        //Enemy and Boss Collision
        if (collision.gameObject.CompareTag("Basic Enemy") || CompareTag("Boss Enemy"))
        {
            //Gets the enemy's health then subtracts the bullets damage from it.
            collision.gameObject.GetComponent<Enemy_Manager>().Enemy_health -= Bullet_Damage;

            GameObject Prefab = Instantiate(Damage_Pop_Up, transform.position, Quaternion.identity);
            Prefab.GetComponentInChildren<TextMesh>().text = Bullet_Damage.ToString();

            //deletes the bullet if bounce is turned off.
            if (canBounce != true)
            {
                Destroy(gameObject);
            }
        }

        //If the object bounces more than is allowed it will destroy itself.
        currentBounces += 1;
        if (currentBounces == maxBounces || currentBounces > maxBounces)
        {
            Destroy(gameObject);
        }
    }
}
