//This script loads when the game starts and should never unload. It stores important data for other scripts to reference even when the scene changes.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Manager : MonoBehaviour
{
    public static Master_Manager Instance;

    //Runs when the object is first created.
    private void Awake()
    {
        //Singleton so that there is only ever one Instance of this object.
        if (Instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate Master_Manager deleted");
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    //-----Variables------------------------------------------
    //Notes: Maybe turn some of these in arrays?
            //The only problem I see with that would be having to memorize the index values or make a bunch of notes saying what each index should be.


    //Game Settings

    //Money Saved Up
    public static float Money_Saved = 0;

    //Shop Upgrade Levels
    public static int S_Health_Upgrade_Level = 0;
    public static int S_Speed_Upgrade_Level = 0;
    public static int S_Luck_Upgrade_Level = 0;
    public static int S_Attack_Damage_Upgrade_Level = 0;
    public static int S_Attack_Speed_Upgrade_Level = 0;
    public static int S_Attack_Size_Upgrade_Level = 0;

    //Shop upgrade costs
    public static float S_Health_Upgrade_Cost;
    public static int S_Speed_Upgrade_Cost;
    public static int S_Luck_Upgrade_Cost;
    public static int S_Attack_Damage_Upgrade_Cost;
    public static int S_Attack_Speed_Upgrade_Cost;
    public static int S_Attack_Size_Upgrade_Cost;

    //Stats For Log Book
    public static float L_Total_Money;
    public static int L_Total_Kills;
    public static float L_Total_Time_Open; //Tracks how long the application has been open for.

    //-----Functions------------------------------------------
    private void Update()
    {
        L_Total_Time_Open += Time.unscaledDeltaTime; //Still updates even if the game is paused.
    }

    //When this is called it will update the prices of the shop upgrades.
    //This is usually called when entering the shop and after clicking an upgrade button.
    static public void Update_Shop_Prices()
    {
        S_Health_Upgrade_Cost = (S_Health_Upgrade_Level * 10) + 10;
        S_Speed_Upgrade_Cost = (S_Speed_Upgrade_Level * 10) + 10;
        S_Luck_Upgrade_Cost = (S_Luck_Upgrade_Level * 10) + 10;
        S_Attack_Damage_Upgrade_Cost = (S_Attack_Damage_Upgrade_Level * 10) + 10;
        S_Attack_Speed_Upgrade_Cost = (S_Attack_Speed_Upgrade_Level * 10) + 10;
        S_Attack_Size_Upgrade_Cost = (S_Attack_Size_Upgrade_Level * 10) + 10;
    }

    //Resets the Shop Upgrade Levels to 0
    static public void Reset_Shop_Levels()
    {
        S_Health_Upgrade_Level = 0;
        S_Speed_Upgrade_Level = 0;
        S_Luck_Upgrade_Level = 0;
        S_Attack_Damage_Upgrade_Level = 0;
        S_Attack_Speed_Upgrade_Level = 0;
        S_Attack_Size_Upgrade_Level = 0;
    }
}
