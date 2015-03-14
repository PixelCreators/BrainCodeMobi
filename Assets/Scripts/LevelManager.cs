using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Houses;
    public bool GameOver;
    public float Speed;
    public float minRandomTime, maxRandomTime;
    public float acceleration;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
            Speed += acceleration * Time.deltaTime;
        else
            StopCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (!GameOver)
        {
            yield return new WaitForSeconds(Random.Range(minRandomTime, maxRandomTime));

            int rand = Random.Range(0, Houses.Length);

            Instantiate(Houses[rand], Vector3.zero, Quaternion.identity);
        }
    }
}