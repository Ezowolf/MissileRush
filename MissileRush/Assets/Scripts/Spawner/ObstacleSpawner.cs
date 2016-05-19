using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField] private string alien1, alien2, satalite, asteroid1, asteroid2;

    void Start()
    {
        BackgroundScroller.OnDespawn += DebugID;
    }
    void DebugID(int id)
    {
        Debug.Log(id);
        SpawnObstacle(id);
    }

    void SpawnObstacle(int id)
    {
        if (id > 15)
        {
            //randomize between all 4 obstacles
            int random = Random.Range(0, 3);
            RandomizeSpawn(random);
        }
        else
        {
            //randomize between 3 obstacles excluding asteroids
            int random = Random.Range(0, 5);
            RandomizeSpawn(random);
        } 
    }

    void RandomizeSpawn(int random)
    {
        switch (random)
        {
            case 0:
                //alien ship
                ObjectPool.instance.GetObjectForType(alien1, true);
                break;
            case 1:
                //alien ship
                ObjectPool.instance.GetObjectForType(alien2, true);
                break;
            case 2:
                //satalite
                ObjectPool.instance.GetObjectForType(satalite, true);
                break;
            case 3:
                //asteroid 1
                ObjectPool.instance.GetObjectForType(asteroid1, true);
                break;
            case 4:
                //asteroid 2
                ObjectPool.instance.GetObjectForType(asteroid2, true);
                break;
        }
    }
}
