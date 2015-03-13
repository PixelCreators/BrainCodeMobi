using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    void Start()
    {
        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }

 
    void Update()
    {
    }
}
