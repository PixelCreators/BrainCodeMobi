using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private new Transform transform;

    public ButtonScript left;
    public ButtonScript right;

    public float speed = 2.0f;

    void Start()
    {
        transform = gameObject.transform;
    }

    void Update()
    {
        if(left.isHoldDown)
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        
        if(right.isHoldDown)
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        
    }
}