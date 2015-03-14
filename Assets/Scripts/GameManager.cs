using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class GameManager : MonoBehaviour
{
    static public GameObject instance;
    

    public int Points;
    public int Highscore;

    void Start()
    {
        if (instance == null)
            instance = this.gameObject;
        else if (instance != this.gameObject)
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);


        
        Load();
    }

 
    void Update()
    {

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/highscore.hs");

        HighScoresData data = new HighScoresData();
        data.Highscore = Highscore;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/highscore.hs"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/highscore.hs", FileMode.Open);

            HighScoresData data = (HighScoresData)bf.Deserialize(file);
            file.Close();

            Highscore = data.Highscore;
        }
        else
        {
            Highscore = 0;
        }
    }


}

[Serializable]
class HighScoresData
{
    public int Highscore;
}

