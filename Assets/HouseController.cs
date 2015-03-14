using UnityEngine;
using System.Collections;

public class HouseController : MonoBehaviour
{

    private Transform killZone;
    private new Transform transform;

    void Start()
    {
        killZone = GameObject.Find("BackgroundDespawnPoint").transform;
        transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < killZone.position.y)
            Destroy(gameObject);
    }
}
