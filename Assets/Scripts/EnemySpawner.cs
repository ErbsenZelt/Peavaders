using UnityEngine;
using System.Collections;

public class EnemySpawner : Spawner
{


    public override float SpawnRate()
    {
// Change Function to whatever you want 
        return Mathf.Clamp(5 - Mathf.Log((Time.time) / 120 + 1), 0.5f, 10);
    }
}
