using UnityEngine;
using System.Collections;

public class CloudsRespawn : MonoBehaviour
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
        if (transform.position.x > despawnPoint.position.x)
            transform.position = spawnPoint.position;
    }
}