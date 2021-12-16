using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string FILE_NAME = "/savefile.json";

    public static GameManager Instance { get; private set; }

    public string PlayerName { get; set; }
    public HighScoreData HighScoreData { get; set; }

    private void Awake()
    {
        if ( Instance != null )
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    public void SaveHighScore(int score)
    {
        HighScoreData data = new HighScoreData
        {
            PlayerName = PlayerName,
            HighScore = score
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + FILE_NAME, json);

    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + FILE_NAME;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            HighScoreData = data;
        }
    }
}

[System.Serializable]
public class HighScoreData
{
    public string PlayerName;
    public int HighScore;
}
