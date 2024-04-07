using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerButton : MonoBehaviour
{
    public void Clicked()
    {
        Game_Control.ResetPlayerStats();
    }
}
