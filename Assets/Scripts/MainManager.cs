using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public InputField nameInput;
    public int bestScore;
    public string bestName;

    private void Awake()
    {
        //keep code and gameObj to next scene
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScoreAndName();
    }

    //save data
    [System.Serializable]
    class SaveData
    {
        public string BestName;
        public int BestScore;
    }

    //save data in jsonfile
    public void SaveBestScoreAndName()
    {
        SaveData data = new SaveData();
        data.BestName = bestName;
        data.BestScore = bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //load data from jsonfile
    public void LoadBestScoreAndName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestName = data.BestName;
            bestScore = data.BestScore;
        }
    }

    //function store bestscore
    public void StoreBestScore()
    {
        //check if bestscore exist
        if (bestScore == null)
        {
            bestScore = 0;
        }
        //check if finalscore more than bestscore - replace bestscore and bestname
        if (GameManager.finalScore > bestScore)
        {
            bestScore = GameManager.finalScore;
            //check if bestName empty
            if (bestName == "")
            {
                bestName = nameInput.text;
            }
        }
    }


}
