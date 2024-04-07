//When the UI is Enabled it creates the upgrade options for the player. Once it is disabled it will delete the upgrade options generated so new ones can spawn.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Up_UI : MonoBehaviour
{
    public GameObject[] upgradeOptions;
    public GameObject[] upgradeSpawnLocations;
    private readonly GameObject[] Upgrade_Choice = new GameObject[3];

    private readonly int[] Upgrades_Picked = new int[3];
    private void OnEnable()
    {
        //Nullifies the upgrades picked so they can be used again.
        Upgrades_Picked[0] = -1;
        Upgrades_Picked[1] = -1;
        Upgrades_Picked[2] = -1;

        //Creates the Upgrade Objects
        Upgrade_Choice[0] = Instantiate(upgradeOptions[PickChoice(1)], upgradeSpawnLocations[0].transform);
        Upgrade_Choice[1] = Instantiate(upgradeOptions[PickChoice(2)], upgradeSpawnLocations[1].transform);
        Upgrade_Choice[2] = Instantiate(upgradeOptions[PickChoice(3)], upgradeSpawnLocations[2].transform);
    }

    //This is ran to generate upgrade choice. The number it takes is used to determine 
    private int PickChoice(int choice)
    {
        //Variable Declaration
        int _option;

        //Generates a random number between 0 and the length of the upgradeOptions array
        _option = Random.Range(0, upgradeOptions.Length);
        //Loops until an upgrade that hasn't already been choose is used.
        while (_option == Upgrades_Picked[0] || _option == Upgrades_Picked[1] || _option == Upgrades_Picked[2])
        {
            Debug.Log(_option + " Has already been picked. Randomizing Again");
            _option = Random.Range(0, upgradeOptions.Length);
        }

        //Stores the choice so it can't be picked again
        Upgrades_Picked[choice - 1] = _option; //Lowers the number by 1 so it goes to the correct index.

        //returns the Final value
        return _option;
    }

    private void OnDisable()
    {
        Destroy(Upgrade_Choice[0]);
        Destroy(Upgrade_Choice[1]);
        Destroy(Upgrade_Choice[2]);
    }
}
