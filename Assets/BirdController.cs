using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour
{
    private new Transform transform;
    public LevelManager levelManager;
    public GameObject explosionPrefab;
    private Transform killZone;
    public AudioClip dieSound;

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
        if(other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(dieSound, Vector3.zero);
            levelManager.Lives--;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}