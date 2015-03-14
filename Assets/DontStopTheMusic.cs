using UnityEngine;
using System.Collections;

public class DontStopTheMusic : MonoBehaviour
{
    public static GameObject instance;

    void Start()
    {
        if (instance == null)
            instance = this.gameObject;
        else if(instance != this.gameObject)
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);
    }


}