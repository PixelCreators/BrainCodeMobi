using UnityEngine;
using System.Collections;

public class MainManuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

public void StartButton()
    {
        Application.LoadLevel("Game");
    }

    public void HightButton()
    {
        Application.LoadLevel("HightScore");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}