using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour
{
    private new Transform transform;
    public float Speed = 0.2f;

    void Start()
    {
        transform = gameObject.transform;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
