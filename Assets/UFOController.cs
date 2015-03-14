using UnityEngine;
using System.Collections;

public class UFOController : MonoBehaviour
{
    PlayerController playerController;

    public float time = 5.0f;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(playerController.InverseAxis(time));
        }
    }
}