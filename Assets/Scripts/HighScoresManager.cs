using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresManager : MonoBehaviour
{

    [SerializeField] Text namesText;
    [SerializeField] Text scoresText;

    List<(string, int)> scores;

    private void Awake()
    {

        Debug.Log("Awake Running");
    }
    // Start is called before the first frame update
    void Start()
    {
        DisplayHighScores();
    }

    private void DisplayHighScores()
    {
        Debug.Log("Trying to display scores");
        scores = MainManager.Instance.highScores;

        ListNames();
        ListScores();
    }

    private void ListNames()
    {
        string text = "";
        

        for (int i = 0; i < scores.Count; i++)
        {
            text += (i+1) + "   " + scores[i].Item1 + "\n";
        }

        namesText.text = text;
    }

    private void ListScores()
    {
        string text = "";

        for (int i = 0; i < scores.Count; i++)
        {
            text += ": " + scores[i].Item2 + "\n";
        }

        scoresText.text = text;
    }
}
