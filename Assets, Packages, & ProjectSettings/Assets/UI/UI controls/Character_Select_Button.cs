using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Select_Button : MonoBehaviour
{
    public string scene_name;
    public string character_name;
    public GameObject self;
    public void Click_Start()
    {
        Debug.Log(self.name + " Button Clicked");
        SceneManager.LoadScene(scene_name);
    }
}
