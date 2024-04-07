using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float Min_Spawn_Time;

    [SerializeField] private float Max_Spawn_Time;

    private float Time_Until_Spawn;

    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        Time_Until_Spawn -= Time.deltaTime;

        if(Time_Until_Spawn <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        switch (Game_Control.Game_Total_Time)
        {
            case (<= 20):
                Time_Until_Spawn = Random.Range(Min_Spawn_Time, Max_Spawn_Time);
                break;
            case (> 20 and <= 40):
                Time_Until_Spawn = Random.Range(Min_Spawn_Time, Max_Spawn_Time - 1);
                break;
            case (> 40 and <= 80):
                Time_Until_Spawn = Random.Range(Min_Spawn_Time - 0.5f, Max_Spawn_Time - 2);
                break;
            case (> 80):
                Time_Until_Spawn = Random.Range(Min_Spawn_Time - 0.9f, Max_Spawn_Time - 2.5f);
                break;
        }
    }
}
