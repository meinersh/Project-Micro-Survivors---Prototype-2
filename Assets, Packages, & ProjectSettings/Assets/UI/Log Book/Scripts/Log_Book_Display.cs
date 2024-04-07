using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Log_Book_Display : MonoBehaviour
{
    public TextMeshProUGUI Game_Stats;

    private int Hours;
    private int Minutes;
    private int Seconds;

    public GameObject[] Log_Book_Items;
    /* Index Reference
     0. Template
     */

    // Update is called once per frame
    void Update()
    {
        Hours = (int)Master_Manager.L_Total_Time_Open / 3600;
        Minutes = ((int)Master_Manager.L_Total_Time_Open / 60) - (Hours * 60);
        Seconds = (int)Master_Manager.L_Total_Time_Open - (Minutes * 60);

        Game_Stats.text = "Game Stats\nTotal Money: " + Master_Manager.L_Total_Money + "\nTotal Kills: " + Master_Manager.L_Total_Kills + "\nTotal Time Open: " + Hours + ":" + Minutes + ":" + Seconds;
    }

    public void Log_Item_Clicked(int value)
    {
        //Turns off all the item displays
        for(int i = 0; i < Log_Book_Items.Length; i++)
        {
            Log_Book_Items[i].SetActive(false);
        }

        //Turns on the selected item display
        Log_Book_Items[value].SetActive(true);
        Debug.Log("Log book now displaying " + Log_Book_Items[value].name);
    }
}
