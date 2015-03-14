using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour
{
    private LevelManager levelManager;
    public float time = 0.1f;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        Destroy(gameObject, time);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Target")
        {
            Debug.Log("Trafiłem!");
        }
    }
}