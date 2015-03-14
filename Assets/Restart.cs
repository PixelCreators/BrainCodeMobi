using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour
{
    public void Restart()
    {
        Application.LoadLevel("Game");
    }
}