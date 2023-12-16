using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager Instance;

    public string highScorePlayersName;
    public int highScorePlayersScore;
    public string currentScorePlayersName;
    public int currentScorePlayersScore;

    public TextMeshProUGUI highestScoreTextFG;
    public TextMeshProUGUI highestScoreTextBG;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameData();
        highestScoreTextBG.text = ("Best Score: " + SaveDataManager.Instance.highScorePlayersName + " : " + SaveDataManager.Instance.highScorePlayersScore);
        highestScoreTextFG.text = ("Best Score: " + SaveDataManager.Instance.highScorePlayersName + " : " + SaveDataManager.Instance.highScorePlayersScore);
    }

    [System.Serializable]

    private class SaveData
    {
        public string highScorePlayersName;
        public int highScorePlayersScore;
        public string currentScorePlayersName;
        public int currentScorePlayersScore;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.currentScorePlayersName = currentScorePlayersName;
        data.currentScorePlayersScore = currentScorePlayersScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/highscoresavefile2.json", json);
    }
    
    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/highscoresavefile2.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayersName = data.currentScorePlayersName;
            highScorePlayersScore = data.currentScorePlayersScore;
        }
    }
}
