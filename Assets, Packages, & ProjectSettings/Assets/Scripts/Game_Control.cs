//The main script of the game.
//Store the players stats as static variables so they are universal for all scripts that need them.
//Controls when the game should be pauses or resumed.
//Activates the Level Up menu when they player levels up.

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game_Control : MonoBehaviour
{
    //--------Variables------------

    //Player Base Stats. These change based on what character is selected. Currently hardcoded here.
    static public float Base_Player_Health_Max = 10;
    static public float Base_Player_Health_Regen = 1;
    static public float Base_Player_Speed = 2;
    static public float Base_Player_Size = 1;
    static public float Base_Player_Luck = 1;
    static public float Base_Player_Attack_Speed = 1;
    static public float Base_Player_Attack_Damage = 1;
    static public float Base_Player_Attack_Size = 1;
    static public float Base_Player_Projectile_Duration = 1;

    //Player XP Stats
    static public float Player_XP = 0;
    static public int Player_Level = 1;
    static public float Player_XP_To_Level = Player_Level * 100;

    //Current Player Character Stats
    static public float Player_Health; //Current Health of the Player
    static public float Player_Health_Max; //Max possible health of the Player
    static public float Player_Health_Regen; //How much health the player heals per second
    static public float Player_Speed; //Player Movement speed
    static public float Player_Size; //Size of the Player character
    static public float Player_Luck; //Has an influnce on randomized calculations. The high it is the better the outcome for the player. The lower the worse outcome for the player.
    static public float Player_Attack_Speed; //How fast the player can attack with the current weapon
    static public float Player_Attack_Damage; //How much damage the player does to enemies. This stat is multiplied with the attacks base damage to calculate the final damage.
    static public float Player_Attack_Size; //Changes the size of the attack hitbox
    static public float Player_Projectile_Duration; //Changes how long a projectile can exist for.

    //Money Related Stats
    static public float Player_Money;

    //The Player Character
    private GameObject Player;

    //Game UIs
    public GameObject Player_UI;
    public GameObject Level_Up_UI;
    public GameObject Game_Over_UI;

    //UI event System
    public EventSystem EventSystem;

    //Game Stats
    static public int Game_Kills;
    static public float Game_Total_Time;

    //Upgrades Stats
    static public int Health_Upgrade_Level; //Increase Max Health by 100 each level.
    static public int Speed_Upgrade_Level; //Increases player speed by 0.2 each level
    static public int Player_Size_Upgrade_Level; //Increase player size by 0.2 each level
    static public int Luck_Upgrade_Level; //Increase luck by 1 each level
    static public int Attack_Speed_Upgrade_Level; //Increases Attack Speed by 0.1 each level
    static public int Attack_Damage_Upgrade_Level; //Increase player attack damage by 1 each level
    static public int Attack_Size_Upgrade_Level; //Increase attack size by 0.2 each level.
    static public int Projectile_Duration_Level;

    //Upgrades Special
    static public bool Projectile_Bounce;
    static public int Max_Projectile_Bounce_Level;

    //boolean variable for other objects to reference if the game is paused or not.
    static public bool GamePaused;
    static public bool UpgradeMenuOpen;

    public static Game_Control Instance;

//--------Start of Functions--------

// Start is called before the first frame update
    void Start()
    {
        Game_Total_Time = 0; //Sets the Game time to 0

        UpdatePlayerStats();
        ResetPlayerStats();
        //Unpauses the game if it was paused
        ResumeGame();

        //Closes the Upgrade Menu if it was open
        UpgradeMenuOpen = false;

        //Sets the player stats when the level starts
        Player_Health = Player_Health_Max;
        //Player_XP = 0;
        //Player_Level = 1;
        //Player_XP_To_Level = Player_Level * 100;

        //Locates the player object in the scene
        Player = GameObject.FindWithTag("Player");

        Game_Over_UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Game_Total_Time += Time.deltaTime; //Pauses when the game is paused.

        //Updates the player's stats every frame
        UpdatePlayerStats();

        //Checks if the upgrade menu should be closed.
        if(UpgradeMenuOpen == false)
        {
            Level_Up_UI.SetActive(false);
        }

        //Checks if the Player has enough XP to level up
        if(Player_XP >= Player_XP_To_Level)
        {
            LevelUp();
        }

        //Checks if there is a player object in the Scene
        if(Player == true)
        {
            //Checks if the player's health is at or below 0
            if(Player_Health <= 0)
            {
                GameOver();
            }

            //If the player has more health than their max health it will be set back to their maximum.
            if(Player_Health > Player_Health_Max)
            {
                Player_Health = Player_Health_Max;
            }
        }

        //Gets Keyboard Input to resume the game
        if(Input.GetKeyDown(KeyCode.Escape) && GamePaused == true)
        {
            ResumeGame();
        }

        //Gets Keyboard Input to pause the game
        if (Input.GetKeyDown(KeyCode.H) && GamePaused == false)
        {
            PauseGame();
        }
    }

    //Starts the gameover process
    void GameOver()
    {
        //Pauses the game and deletes the player.
        Master_Manager.L_Total_Kills += Game_Kills;
        Master_Manager.L_Total_Money += Player_Money;
        Master_Manager.Money_Saved += Player_Money;
        PauseGame();
        Game_Over_UI.SetActive(true);
        Destroy(Player);
    }

    //Pauses the game
    static public void PauseGame()
    {
        //Sets the time scale to 0 which stops things from moving. Doesn't pause update scripts from running! Ui buttons should still work unless told otherwise.
        Time.timeScale = 0;
        GamePaused = true;

        Debug.Log("Game is now paused");
        Debug.Log("Current Time Scale is: " + Time.timeScale);
    }

    //Resumes the Game
    static public void ResumeGame()
    {
        //Sets the time scale to 1 which should cause the game to run like normal.
        Time.timeScale = 1;
        GamePaused = false;

        Debug.Log("Game is now resumed");
        Debug.Log("Current Time Scale is: " + Time.timeScale);
    }

    //When Called Levels up player and opens the level Up menu.
    void LevelUp()
    {
        Player_XP -= Player_XP_To_Level; //Takes away the amount of XP needed to level
        Player_Level++; //Increase the player level by 1.
        Player_XP_To_Level = Player_Level * 100; //Increases the amount of XP needed for the next level

        //Tells the game to open the upgrade menu.
        UpgradeMenuOpen = true;
        Level_Up_UI.SetActive(true);
        PauseGame();

        //The game locates one of the Upgrade buttons that is reactivated
        GameObject UpgradeButton = GameObject.FindWithTag("Upgrade Button");

        //Enables Keyboard input for the Level UI buttons otherwise the player would have to click it before it was eneabled.
        EventSystem.SetSelectedGameObject(UpgradeButton);
    }

    //Updates all of the player's stats
    void UpdatePlayerStats()
    {
        //The stat increase formula typically looks like this: stat = base_stat + (Upgrade_Level * Stat_Per_Level) + (Shop_Upgrade_Level * Stat_Per_Level) + other upgrades if there are any

        Player_Health_Max = Base_Player_Health_Max + (Health_Upgrade_Level * 10) + (Master_Manager.S_Health_Upgrade_Level * 2);
        Player_Speed = Base_Player_Speed + (Speed_Upgrade_Level * 0.2f) + (Master_Manager.S_Speed_Upgrade_Level * 0.05f);
        Player_Size = Base_Player_Size + (Player_Size_Upgrade_Level * 0.2f);
        Player_Luck = Base_Player_Luck + (Luck_Upgrade_Level * 0.2f) + (Master_Manager.S_Luck_Upgrade_Level * 0.05f);
        Player_Attack_Damage = Base_Player_Attack_Damage + (Attack_Damage_Upgrade_Level * 0.2f) + (Master_Manager.S_Attack_Damage_Upgrade_Level * 0.05f); //When this is used for the player's attacks the equation should be: Base_Attack_Damage * Player_Attack_Damage
        Player_Attack_Speed = Base_Player_Attack_Speed + (Attack_Speed_Upgrade_Level * 0.2f) + (Master_Manager.S_Attack_Speed_Upgrade_Level * 0.05f); //When a weapon uses this stat the equation should be: Base_Cooldown / Player_Atack_Speed
        Player_Attack_Size = Base_Player_Attack_Size + (Attack_Size_Upgrade_Level * 0.1f) + (Master_Manager.S_Attack_Size_Upgrade_Level * 0.025f); //Probably Removing this. I think it will cause to many problems with the normal gameplay flow.
        Player_Projectile_Duration = Base_Player_Projectile_Duration + (Projectile_Duration_Level * 0.2f);
    }

    static public void ResetPlayerStats()
    {
        //Resets Game Per Stats
        Player_Money = 0;
        Game_Kills = 0;

        //Resetes Level and XP stats
        Player_Level = 1;
        Player_XP = 0;
        Player_XP_To_Level = Player_Level * 100;

        //Resets Level Upgrades
        Health_Upgrade_Level = 0;
        Speed_Upgrade_Level = 0;
        Player_Size_Upgrade_Level = 0;
        Luck_Upgrade_Level = 0;
        Attack_Damage_Upgrade_Level = 0;
        Attack_Speed_Upgrade_Level = 0;
        Attack_Size_Upgrade_Level = 0;

        //Resets Special Upgrades
        Projectile_Bounce = false;
        Max_Projectile_Bounce_Level = 0;

        Debug.Log("Player's Level and Upgrade Levels have been reset");
    }
}
