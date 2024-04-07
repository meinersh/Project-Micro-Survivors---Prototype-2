using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop_Upgrade_Buttons : MonoBehaviour
{
    private float Current_Money;
    private float Upgrade_Cost;

    public void Clicked(string UpgradeName)
    {
        Current_Money = Master_Manager.Money_Saved;
        //Takes the name of the upgrade choosen and puts it into a switch case.
        switch (UpgradeName)
        {
            //Activates this block if the name inputed matches the case statement.
            case ("Health Upgrade"):
                if(Current_Money >= Master_Manager.S_Health_Upgrade_Cost)
                {
                    //Increases The upgrade level by one
                    Master_Manager.S_Health_Upgrade_Level++;
                    Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Master_Manager.S_Health_Upgrade_Level);
                    Master_Manager.Money_Saved -= Master_Manager.S_Health_Upgrade_Cost;
                }
                else if(Current_Money < Master_Manager.S_Health_Upgrade_Cost)
                {
                    Debug.Log("Not enough money. Current money is: " + Current_Money + " The amount of money needed for " + UpgradeName + " is:" + Master_Manager.S_Health_Upgrade_Cost);
                }
                else
                {
                    Debug.Log("Unknown error when trying to upgrade: " + UpgradeName);
                }

                //Breaks out of the switch
                break;

            case ("Speed Upgrade"):
                if (Current_Money >= Master_Manager.S_Speed_Upgrade_Cost)
                {
                    //Increases The upgrade level by one
                    Master_Manager.S_Speed_Upgrade_Level++;
                    Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Master_Manager.S_Speed_Upgrade_Level);
                    Master_Manager.Money_Saved -= Master_Manager.S_Speed_Upgrade_Cost;
                }
                else if (Current_Money < Master_Manager.S_Speed_Upgrade_Cost)
                {
                    Debug.Log("Not enough money. Current money is: " + Current_Money + " The amount of money needed for " + UpgradeName + " is:" + Master_Manager.S_Speed_Upgrade_Cost);
                }
                else
                {
                    Debug.Log("Unknown error when trying to upgrade: " + UpgradeName);
                }

                //Breaks out of the switch
                break;

            case ("Luck Upgrade"):
                if (Current_Money >= Master_Manager.S_Luck_Upgrade_Cost)
                {
                    //Increases The upgrade level by one
                    Master_Manager.S_Luck_Upgrade_Level++;
                    Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Master_Manager.S_Luck_Upgrade_Level);
                    Master_Manager.Money_Saved -= Master_Manager.S_Luck_Upgrade_Cost;
                }
                else if (Current_Money < Master_Manager.S_Luck_Upgrade_Cost)
                {
                    Debug.Log("Not enough money. Current money is: " + Current_Money + " The amount of money needed for " + UpgradeName + " is:" + Master_Manager.S_Luck_Upgrade_Cost);
                }
                else
                {
                    Debug.Log("Unknown error when trying to upgrade: " + UpgradeName);
                }

                //Breaks out of the switch
                break;

            case ("Attack Damage Upgrade"):
                if (Current_Money >= Master_Manager.S_Attack_Damage_Upgrade_Cost)
                {
                    //Increases The upgrade level by one
                    Master_Manager.S_Attack_Damage_Upgrade_Level++;
                    Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Master_Manager.S_Attack_Damage_Upgrade_Level);
                    Master_Manager.Money_Saved -= Master_Manager.S_Attack_Damage_Upgrade_Cost;
                }
                else if (Current_Money < Master_Manager.S_Attack_Damage_Upgrade_Cost)
                {
                    Debug.Log("Not enough money. Current money is: " + Current_Money + " The amount of money needed for " + UpgradeName + " is:" + Master_Manager.S_Attack_Damage_Upgrade_Cost);
                }
                else
                {
                    Debug.Log("Unknown error when trying to upgrade: " + UpgradeName);
                }

                //Breaks out of the switch
                break;

            case ("Attack Speed Upgrade"):
                if (Current_Money >= Master_Manager.S_Attack_Speed_Upgrade_Cost)
                {
                    //Increases The upgrade level by one
                    Master_Manager.S_Attack_Speed_Upgrade_Level++;
                    Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Master_Manager.S_Attack_Speed_Upgrade_Level);
                    Master_Manager.Money_Saved -= Master_Manager.S_Attack_Speed_Upgrade_Cost;
                }
                else if (Current_Money < Master_Manager.S_Attack_Speed_Upgrade_Cost)
                {
                    Debug.Log("Not enough money. Current money is: " + Current_Money + " The amount of money needed for " + UpgradeName + " is:" + Master_Manager.S_Attack_Speed_Upgrade_Cost);
                }
                else
                {
                    Debug.Log("Unknown error when trying to upgrade: " + UpgradeName);
                }

                //Breaks out of the switch
                break;

            case ("Attack Size Upgrade"):
                if (Current_Money >= Master_Manager.S_Attack_Size_Upgrade_Cost)
                {
                    //Increases The upgrade level by one
                    Master_Manager.S_Attack_Size_Upgrade_Level++;
                    Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Master_Manager.S_Attack_Size_Upgrade_Level);
                    Master_Manager.Money_Saved -= Master_Manager.S_Attack_Size_Upgrade_Cost;
                }
                else if (Current_Money < Master_Manager.S_Attack_Size_Upgrade_Cost)
                {
                    Debug.Log("Not enough money. Current money is: " + Current_Money + " The amount of money needed for " + UpgradeName + " is:" + Master_Manager.S_Attack_Size_Upgrade_Cost);
                }
                else
                {
                    Debug.Log("Unknown error when trying to upgrade: " + UpgradeName);
                }

                //Breaks out of the switch
                break;

            //If Upgrade name is invalid it will run this block. It will Display the name inputed in the Debug log.
            default:
                Debug.Log("No upgrade with the name: " + UpgradeName);
                break;
        }
        Master_Manager.Update_Shop_Prices();

    }
}
