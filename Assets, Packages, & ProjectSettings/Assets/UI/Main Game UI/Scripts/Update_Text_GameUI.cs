//Updates the Player UI text every frame.

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Update_Text : MonoBehaviour
{
    //Gets the text boxes that will be updated for player related stats.
    public TextMeshProUGUI HP_UI;
    public TextMeshProUGUI XP_UI;
    public TextMeshProUGUI Player_Level_UI;
    public TextMeshProUGUI XP_to_Level;
    public TextMeshProUGUI Money_UI;

    //Gets the text boxes that will be updated for Game related stats.
    public TextMeshProUGUI Game_Kills;
    public TextMeshProUGUI Time_UI;

    private int Minutes;
    private int Seconds;

    void Update()
    {
        Minutes = (int)Game_Control.Game_Total_Time / 60;
        Seconds = (int)Game_Control.Game_Total_Time - (Minutes * 60);


        //Update Player Stats UI
        HP_UI.text = "HP: " + Game_Control.Player_Health + " / " + Game_Control.Player_Health_Max;
        XP_UI.text = "XP: " + Game_Control.Player_XP;
        Player_Level_UI.text = "Level: " + Game_Control.Player_Level;
        XP_to_Level.text = "XP needed to level: " + Game_Control.Player_XP_To_Level;

        //Updates Game Stats UI
        Game_Kills.text = "Kills: " + Game_Control.Game_Kills;
        Money_UI.text = "Money: " + Game_Control.Player_Money;
        Time_UI.text = Minutes + ":" + Seconds;
    }
}
