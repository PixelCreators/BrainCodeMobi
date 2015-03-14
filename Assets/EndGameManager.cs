using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public Text points;
    public Text highscore;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Debug.Log(gameManager.Points);
        Debug.Log(gameManager.Highscore);
        if (gameManager.Points > gameManager.Highscore)
        {
            gameManager.Highscore = gameManager.Points;
            gameManager.Save();
        }

        points.text = gameManager.Points.ToString();
    }
}