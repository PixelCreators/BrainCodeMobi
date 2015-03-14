using UnityEngine;
using System.Collections;

public class MoveHorizontally : MonoBehaviour
{
    private new Transform transform;
    private SetRandomPosition setRandomPosition;
    private Animator animator;
    public float speed;
    public float minSpeed, maxSpeed;
    public float smooth = 1.0f;
    
    void Start()
    {
        setRandomPosition = GetComponent<SetRandomPosition>();
        animator = GetComponentInChildren<Animator>();


        speed = Random.Range(minSpeed, maxSpeed);
        transform = gameObject.transform;   
    }

    void Update()
    {
        if(setRandomPosition.xIsWidth)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if(!setRandomPosition.xIsWidth)
        {
            animator.SetBool("Rotated", true);
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
