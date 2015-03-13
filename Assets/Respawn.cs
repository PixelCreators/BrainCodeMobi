using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
    private Transform spawnPoint;
    private Transform despawnPoint;
    private new Transform transform;

    void Start()
    {
        transform = gameObject.transform;
        spawnPoint = GameObject.Find("BackgroundSpawnPoint").transform;
        despawnPoint = GameObject.Find("BackgroundDespawnPoint").transform;
    }

    void Update()
    {
        if(transform.position.y < despawnPoint.position.y)
            transform.position = spawnPoint.position;
    }
}
