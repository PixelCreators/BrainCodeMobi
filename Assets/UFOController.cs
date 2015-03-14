using UnityEngine;
using System.Collections;

public class UFOController : MonoBehaviour
{
    PlayerController playerController;
    public AudioClip ufoSound;
    private Transform killZone;
    public float time = 5.0f;

    void Start()
    {
        killZone = GameObject.Find("BackgroundDespawnPoint").transform;
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (killZone.position.y > transform.position.y)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(ufoSound, Vector3.zero);
            StartCoroutine(playerController.InverseAxis(time));
        }
    }
}