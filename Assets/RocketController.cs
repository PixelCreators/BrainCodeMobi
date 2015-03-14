using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour
{
    public float speed = 1.0f;
    public float maxSpeed;
    private new Transform transform;
    private Animator animator;
    private LevelManager levelManager;
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        animator = GetComponentInChildren<Animator>();
        transform = gameObject.transform;
        speed = Random.Range(levelManager.Speed + 2, maxSpeed);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            animator.SetBool("Die", true);
            Destroy(gameObject, 1f);
        }
    }
}