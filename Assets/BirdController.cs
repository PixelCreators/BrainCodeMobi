using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour
{
    private new Transform transform;
    public LevelManager levelManager;
    public GameObject explosionPrefab;
    private Transform killZone;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        killZone = GameObject.Find("BackgroundDespawnPoint").transform;
        transform = gameObject.transform;
    }

    void Update()
    {
        if (killZone.position.y > transform.position.y)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Player")
        {
            levelManager.Lives--;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}