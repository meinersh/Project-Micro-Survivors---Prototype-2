using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop_UI_Controller : MonoBehaviour
{
    public TextMeshProUGUI Money_Display;
    public TextMeshProUGUI Health_Upgrade_Cost;
    public TextMeshProUGUI Speed_Upgrade_Cost;
    public TextMeshProUGUI Luck_Upgrade_Cost;
    public TextMeshProUGUI Attack_Damage_Upgrade_Cost;
    public TextMeshProUGUI Attack_Speed_Upgrade_Cost;
    public TextMeshProUGUI Attack_Size_Upgrade_Cost;

    // Start is called before the first frame update
    void Start()
    {
        //Makes sure the shop prices are updated correctly
        Master_Manager.Update_Shop_Prices();
    }

    // Update is called once per frame
    void Update()
    {
        Money_Display.text = "Money: " + Master_Manager.Money_Saved;
        Health_Upgrade_Cost.text = "Cost: " + Master_Manager.S_Health_Upgrade_Cost;
        Speed_Upgrade_Cost.text = "Cost: " + Master_Manager.S_Speed_Upgrade_Cost;
        Luck_Upgrade_Cost.text = "Cost: " + Master_Manager.S_Luck_Upgrade_Cost;
        Attack_Damage_Upgrade_Cost.text = "Cost: " + Master_Manager.S_Attack_Damage_Upgrade_Cost;
        Attack_Speed_Upgrade_Cost.text = "Cost: " + Master_Manager.S_Attack_Speed_Upgrade_Cost;
        Attack_Size_Upgrade_Cost.text = "Cost: " + Master_Manager.S_Attack_Size_Upgrade_Cost;

        //Master_Manager.Money_Saved++; //Temp for testing
    }
}
