using UnityEngine;
using System.Collections;

public class MoveDown : MonoBehaviour 
{
    private new Transform transform;
    public float speed = 1.5f;

	// Use this for initialization
	void Start () 
    {
        transform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
	}
}
