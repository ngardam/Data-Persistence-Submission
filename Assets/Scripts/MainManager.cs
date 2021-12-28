using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

    public List<(string, int)> highScores = new List<(string, int)>();

    public static MainManager Instance;

    public string playerName;


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

        SceneManager.LoadScene(0); //load menu on startup

    }

        // Start is called before the first frame update
        void Start()
    {

    }

    private void Update()
    {

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

    [serializable]
    public class SaveData
    {
        public (string, int)[] highScores;
    }
}
