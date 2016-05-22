using UnityEngine;
using System.Collections;

/*
 * this class is responsible for the spawning of the background elements in MissileRush.
 * the planets and clouds in the background are being spawned by this class
 */

public class BGPropSpawner : MonoBehaviour {

    [SerializeField]
    private string planet1, planet2, planet3, planet4, planet5, cloud1, cloud2, cloud3;

    private void Start()
    {
        BackgroundScroller.OnDespawn += SpawnElement;
    }

    void SpawnElement(int id)
    {
        if(id > 13)
        {
            //spawn planets
            int random = Random.Range(0, 5);
            switch(random)
            {
                case 0:
                    //planet1
                    ObjectPool.instance.GetObjectForType(planet1, true);
                    break;
                case 1:
                    //planet2
                    ObjectPool.instance.GetObjectForType(planet2, true);
                    break;
                case 2:
                    //planet3
                    ObjectPool.instance.GetObjectForType(planet3, true);
                    break;
                case 3:
                    //planet4
                    ObjectPool.instance.GetObjectForType(planet4, true);
                    break;
                case 4:
                    //planet5
                    ObjectPool.instance.GetObjectForType(planet5, true);
                    break;
            }
        }
        else if(id < 12)
        {
            //spawn clouds
            int random = Random.Range(0, 6);
            switch(random)
            {
                case 0:
                    //cloud1
                    ObjectPool.instance.GetObjectForType(cloud1, true);
                    break;
                case 1:
                    //cloud2
                    ObjectPool.instance.GetObjectForType(cloud2, true);
                    break;
                case 2:
                    //cloud3
                    ObjectPool.instance.GetObjectForType(cloud3, true);
                    break;
                case 3:
                    //cloud1 + cloud3
                    ObjectPool.instance.GetObjectForType(cloud3, true);
                    ObjectPool.instance.GetObjectForType(cloud1, true);
                    break;
                case 4:
                    ObjectPool.instance.GetObjectForType(cloud1, true);
                    ObjectPool.instance.GetObjectForType(cloud2, true);
                    break;
                case 5:
                    ObjectPool.instance.GetObjectForType(cloud2, true);
                    ObjectPool.instance.GetObjectForType(cloud3, true);
                    break;
            }
        }
    }
}
