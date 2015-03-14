using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public Text points;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        points.text = gameManager.Points.ToString();

        if (gameManager.Points > gameManager.Highscore)
        {
            gameManager.Highscore = gameManager.Points;
            gameManager.Save();
        }
    }
}