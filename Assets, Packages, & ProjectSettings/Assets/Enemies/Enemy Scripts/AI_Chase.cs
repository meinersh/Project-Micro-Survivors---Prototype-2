//Makes the Enemy track the player and move towards them.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Chase : MonoBehaviour
{
    public float DistancePerSecond;

    private GameObject player;
    private Rigidbody2D rb2D;
    //private float distance;

    // Start is called before the first frame update
    void Start()
    {
        //gets it's own rgidbody2D component
        rb2D = GetComponent<Rigidbody2D>();

        //Finds the player character to reference for calculations
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if there is a player object in the scene
        if (player == true)
        {
            //Claculates how far it is from the player.
            //distance = Vector2.Distance(transform.position, player.transform.position);

            //Claculates the direction towards the player from it's current poistion
            Vector3 direction = player.transform.position - this.transform.position;

            direction.Normalize(); //normalizes the dicection because it has 3 vectors when we only need 2.

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Atan2(target y, traget x)

            //moves the enemy towards the player
            rb2D.velocity = direction * DistancePerSecond;

            //rotates the enemy to face the player
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
