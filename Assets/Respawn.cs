using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform despawnPoint;
    private new Transform transform;

    void Start()
    {
        transform = gameObject.transform;
    }

    void Update()
    {
        if(transform.position.y < despawnPoint.position.y)
            transform.position = spawnPoint.position;
    }
}
