using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{

    public List<(string, int)> highScores = new List<(string, int)>();

    public static MainManager Instance;

    public string playerName;

    private int sizeOfHighScoreList = 10;


    private void Awake()
    {

        //test high score
        highScores.Add(("Joe", 1));


        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame();

        SceneManager.LoadScene(0); //load menu on startup



    }

        // Start is called before the first frame update
        void Start()
    {

    }

    private void Update()
    {

    }

    private void SaveGame()
    {
        SaveData saveData = new SaveData();

        saveData.namesArray = CreateNamesArray();
        saveData.scoresArray = CreateScoresArray();

        //saveData.highScores = highScores;

        string myJson = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/highscores.json", myJson);

        Debug.Log("saving");
        
    }

    private void LoadGame()
    {
        string path = Application.persistentDataPath + "/highscores.json";
        if (File.Exists(path))
        {
            Debug.Log("File found");
            string savedJson = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(savedJson);

            LoadHighScoreData(data);


        } else
        {
            Debug.Log("File not found");
        }

    }

    private void LoadHighScoreData(SaveData data)
    {
        highScores.Clear();

        for (int i = 0; i < data.namesArray.Length; i++)
        {
            highScores.Add((data.namesArray[i], data.scoresArray[i]));
        }
    }

    public void SubmitScore(string name, int score)
    {
        //bool inTopTen = false;
        for (int i = 0; i < highScores.Count; i++)
        {
            if (highScores[i].Item2 < score)
            {
                //inTopTen = true;
                highScores.Insert(i, (name, score));
                RemoveEleventhPlace();
                return;
            }

        }
    }

    private void RemoveEleventhPlace()
    {
        if (highScores.Count > 10)
        {
            highScores.RemoveAt(10);
        }
    }

 
    private void StartGame()
    {

    }

    public void SetName(string newName)
    {
        playerName = newName;
    }


    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Loading main scene");
   

    }

    public void ExitGameButton()
    {
        SaveGame();
        EditorApplication.ExitPlaymode(); //only works in Unity Editor
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void HighScoresButton()
    {
        SceneManager.LoadScene(2);
    }

    private string[] CreateNamesArray()
    {
        string[] _nameArray = new string[sizeOfHighScoreList];

        for (int i = 0; i < highScores.Count; i++)
        {
            _nameArray[i] = highScores[i].Item1;
        }

        return _nameArray;
    }

    private int[] CreateScoresArray()
    {
        int[] _scoresArray = new int[sizeOfHighScoreList];

        for (int i = 0; i < highScores.Count; i++)
        {
            _scoresArray[i] = highScores[i].Item2;
        }

        return _scoresArray;
    }

    [serializable]
    public class SaveData
    {
        public string[] namesArray;
        public int[] scoresArray;

        //public List<(string, int)> highScores;
    }
}
