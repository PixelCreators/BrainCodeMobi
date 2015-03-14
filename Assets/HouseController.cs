using UnityEngine;
using System.Collections;

public class HouseController : MonoBehaviour
{
    public GameObject hudParticlePrefab;
    
    public int probality;

    private GameObject childParticle;
    private LevelManager levelManager;
    private Transform killZone;
    private new Transform transform;
    public bool isTarget;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        killZone = GameObject.Find("BackgroundDespawnPoint").transform;
        transform = gameObject.transform;

        int rand = Random.Range(0, probality);
        if (rand == 1)
        {
            isTarget = true;
            childParticle = (GameObject)Instantiate(hudParticlePrefab, transform.position, Quaternion.identity);
            childParticle.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < killZone.position.y)
        {
            if(isTarget)
                levelManager.Lives--;

            Destroy(gameObject);
        }
    }

    
}
