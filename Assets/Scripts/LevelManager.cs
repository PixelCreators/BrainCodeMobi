using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public Text points;

    public GameObject[] Houses;
    public GameObject[] Hudlers;
    public GameObject[] heartImages;
    public GameObject rocketPrefab;

    public GameManager gameManager;

    public bool GameOver;
    public float Speed;
    public float minRandomTime, maxRandomTime;
    public float minRandomHudlerTime, maxRandomHudlerTime;
    public float acceleration;
    public float spawnAcceleration;
    public float hudlerSpawnAcceleration;
    public int Points;
    public int Lives;
    public int rocketPropability;


    public bool Shot;
    //TODO: Remove above line

    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(SpawnHudlers());
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnRocket());
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            if (Lives == 2)
                heartImages[2].SetActive(false);
            if (Lives == 1)
                heartImages[1].SetActive(false);
            if (Lives == 0)
            {
                heartImages[2].SetActive(false);
                heartImages[1].SetActive(false);
                heartImages[0].SetActive(false);
                GameOver = true;
            }


            if (minRandomTime >= 0.1f) minRandomTime -= spawnAcceleration * Time.deltaTime;
            if (maxRandomTime >= 0.3f) maxRandomTime -= spawnAcceleration * Time.deltaTime;


            if (minRandomHudlerTime >= 1f) minRandomHudlerTime -= hudlerSpawnAcceleration * Time.deltaTime;
            if (maxRandomHudlerTime >= 2f) maxRandomHudlerTime -= hudlerSpawnAcceleration * Time.deltaTime;

            if(Speed < 6)
                Speed += acceleration * Time.deltaTime;

            points.text = Points.ToString();
        }
        else
        {
            gameManager.Points = Points;
            StopCoroutine(SpawnEnemies());
            StopCoroutine(SpawnHudlers());
            StopCoroutine(SpawnRocket());
            StartCoroutine(WaitAndLoadGameOver());
            
        }
    }

    private IEnumerator WaitAndLoadGameOver()
    {
        yield return new WaitForSeconds(1f);

        Application.LoadLevel("GameOver");
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

    private IEnumerator SpawnRocket()
    {
        while(!GameOver)
        {
            yield return new WaitForSeconds(1f);
            
            int rand = Random.Range(1, rocketPropability);

            if(rand == 1)
            {
                Instantiate(rocketPrefab, Vector3.zero, Quaternion.identity);
            }
        }
    }

    public void AddPoints(int points)
    {
        Points += points;
    }
}