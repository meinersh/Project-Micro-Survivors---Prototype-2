//When the button is clicked it takes the string that is set in the inspector and puts it into a switch statement. Based on that string it selects the relavent upgrade and increases the level by 1.

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Upgrade_Confirm : MonoBehaviour
{
    //Activates when button is clicked. The button will send the name of the upgrade the player choose.
    public void Clicked(string UpgradeName)
    {
        //Takes the name of the upgrade choosen and puts it into a switch case.
        switch(UpgradeName)
        {
            //Activates this block if the name inputed matches the case statement.
            case ("Health Upgrade"):
                //Increases The upgrade level by one
                Game_Control.Health_Upgrade_Level++;
                Game_Control.Player_Health += 100; //Instantly heals the player for the Max health they just recieved.
                Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Game_Control.Health_Upgrade_Level);
                //Breaks out of the switch
                break;

            case ("Speed Upgrade"):
                //Increases The upgrade level by one
                Game_Control.Speed_Upgrade_Level++;
                Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Game_Control.Speed_Upgrade_Level);
                //Breaks out of the switch
                break;

            case ("Player Size Upgrade"):
                //Increases The upgrade level by one
                Game_Control.Player_Size_Upgrade_Level++;
                Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Game_Control.Player_Size_Upgrade_Level);
                //Breaks out of the switch
                break;

            case ("Luck Upgrade"):
                //Increases The upgrade level by one
                Game_Control.Luck_Upgrade_Level++;
                Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Game_Control.Luck_Upgrade_Level);
                //Breaks out of the switch
                break;

            case ("Attack Damage Upgrade"):
                //Increases The upgrade level by one
                Game_Control.Attack_Damage_Upgrade_Level++;
                Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Game_Control.Attack_Damage_Upgrade_Level);
                //Breaks out of the switch
                break;

            case ("Attack Speed Upgrade"):
                //Increases The upgrade level by one
                Game_Control.Attack_Speed_Upgrade_Level++;
                Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Game_Control.Attack_Speed_Upgrade_Level);
                //Breaks out of the switch
                break;

            case ("Attack Size Upgrade"):
                //Increases The upgrade level by one
                Game_Control.Attack_Size_Upgrade_Level++;
                Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Game_Control.Attack_Size_Upgrade_Level);
                //Breaks out of the switch
                break;

            case ("Bounce Upgrade"):
                if (Game_Control.Projectile_Bounce == true)
                {
                    Game_Control.Max_Projectile_Bounce_Level++;
                    Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Game_Control.Max_Projectile_Bounce_Level);
                }
                else if (Game_Control.Projectile_Bounce == false)
                {
                    Game_Control.Projectile_Bounce = true;
                    Debug.Log(UpgradeName + " is now set to: " + Game_Control.Projectile_Bounce);
                }
                break;

            case ("Duration Upgrade"):
                //Increases The upgrade level by one
                Game_Control.Projectile_Duration_Level++;
                Debug.Log(UpgradeName + " has been increase by one level. It is now level: " + Game_Control.Projectile_Duration_Level);
                //Breaks out of the switch
                break;

            //If Upgrade name is invalid it will run this block. It will Display the name inputed in the Debug log.
            default:
                Debug.Log("No upgrade with the name: " + UpgradeName);
                break;
        }
        //Tells the game to close the upgrade menu.
        Game_Control.UpgradeMenuOpen = false;
        Game_Control.ResumeGame();
    }
}
