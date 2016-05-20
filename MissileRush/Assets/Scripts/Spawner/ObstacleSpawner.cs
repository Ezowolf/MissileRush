using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField] private string alien1, alien2, satalite, asteroid1, asteroid2, motherShip;

    private int spawnCooldown;

    void Start()
    {
        BackgroundScroller.OnDespawn += DebugID;
    }

    void FixedUpdate()
    {
        if (spawnCooldown > 0)
            spawnCooldown--;
        else
            spawnCooldown = 0;
    }

    void DebugID(int id)
    {
        if(spawnCooldown == 0)
        {
            SpawnObstacle(id);
            spawnCooldown = 80;
        }
    }

    void SpawnObstacle(int id)
    {
        if (id > 15)
        {
            if(id >= 25)
            {
                Debug.Log("Spawn Mothership");
                int random = Random.Range(5, 6);
                RandomizeSpawn(random);
            }
            else
            {
                //randomize between all 5 obstacles
                int random = Random.Range(0, 5);
                RandomizeSpawn(random);
                Debug.Log("can spawn everything " + id);
            }
            
        }
        else
        {
            //randomize between 2 obstacles excluding asteroids & satalite
            int random = Random.Range(0, 2);
            RandomizeSpawn(random);
            Debug.Log("Can only spawn enemy " + id);
        } 
    }

    void OnDisable()
    {
        BackgroundScroller.OnDespawn -= DebugID;
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
                Debug.Log("spawn satalite");
                break;
            case 3:
                //asteroid 1
                ObjectPool.instance.GetObjectForType(asteroid1, true);
                Debug.Log("Spawn asteroid 1");
                break;
            case 4:
                //asteroid 2
                ObjectPool.instance.GetObjectForType(asteroid2, true);
                Debug.Log("Spawn asteroid 2");
                break;
            case 5:
                ObjectPool.instance.GetObjectForType(motherShip, true);
                break;
        }
    }
}
