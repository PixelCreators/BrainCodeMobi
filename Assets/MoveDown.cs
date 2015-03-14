using UnityEngine;
using System.Collections;

public class MoveDown : MonoBehaviour 
{
    private new Transform transform;
    private LevelManager levelManager;
    public bool isCloud = false;
    public float speed;

	// Use this for initialization
	void Start () 
    {
        levelManager = FindObjectOfType<LevelManager>();
        transform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        speed = levelManager.Speed;

        if (isCloud)
            speed /= 10;
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
	}
}
