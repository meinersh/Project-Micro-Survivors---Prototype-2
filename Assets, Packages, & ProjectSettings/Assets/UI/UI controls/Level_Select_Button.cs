using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Select_Button : MonoBehaviour
{
    public string scene_name;
    public string level_name;
    public GameObject self;
    public void Click_Start()
    {
        Debug.Log(self.name + " Button Clicked");
        SceneManager.LoadScene(scene_name);
    }
}
