using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public Text points;

    public GameObject[] Houses;
    public GameObject[] Hudlers;

    public bool GameOver;
    public float Speed;
    public float minRandomTime, maxRandomTime;
    public float minRandomHudlerTime, maxRandomHudlerTime;
    public float acceleration;
    public float spawnAcceleration;
    public float hudlerSpawnAcceleration;
    public int Points;

    public bool Shot;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnHudlers());
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            if (minRandomTime >= 0.1f) minRandomTime -= spawnAcceleration * Time.deltaTime;
            if (maxRandomTime >= 0.3f) maxRandomTime -= spawnAcceleration * Time.deltaTime;


            if (minRandomHudlerTime >= 1f) minRandomHudlerTime -= hudlerSpawnAcceleration * Time.deltaTime;
            if (maxRandomHudlerTime >= 2f) maxRandomHudlerTime -= hudlerSpawnAcceleration * Time.deltaTime;

            Speed += acceleration * Time.deltaTime;

            points.text = "Points: " + Points.ToString();
        }
        else
        {
            StopCoroutine(SpawnEnemies());
            StopCoroutine(SpawnHudlers());
        }
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

    private IEnumerator SpawnHudlers()
    {
        while (!GameOver)
        {
            yield return new WaitForSeconds(Random.Range(minRandomHudlerTime, maxRandomHudlerTime));

            int rand = Random.Range(0, Hudlers.Length);

            Instantiate(Hudlers[rand], Vector3.zero, Quaternion.identity);
        }
    }

    public void AddPoints(int points)
    {
        Points += points;
    }
}