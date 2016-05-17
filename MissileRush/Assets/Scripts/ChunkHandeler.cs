using UnityEngine;
using System.Collections;

/*
 * This script will enable a chunk in the scene when one is being disabled
 * and keep track of how many chunks have been enabled
 */

public class ChunkHandeler : MonoBehaviour {

    private GameObject[] chunks = new GameObject[29];

    private 

    void Start()
    {
        BackgroundScroller.OnDespawn += SpawnNewBackground;

        ObjectPool.instance.GetObjectForType("1BG", true);
        ObjectPool.instance.GetObjectForType("2BG", true);
    }

    void SpawnNewBackground(int id)
    {
        ObjectPool.instance.GetObjectForType((id +3)+ "BG", true);
    }
}
