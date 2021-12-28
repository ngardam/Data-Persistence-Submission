using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{

    [SerializeField] InputField inputField;

    public void StartGameButton()
    {
        MainManager.Instance.StartGameButton();
    }

    public void ExitGameButton()
    {
        MainManager.Instance.ExitGameButton();
    }

    public void SetName()
    {
        string _name = inputField.text;

        MainManager.Instance.SetName(_name);
    }

    public void MainMenuButton()
    {
        MainManager.Instance.MainMenuButton();
    }

    public void HighScoresButton()
    {
        MainManager.Instance.HighScoresButton();
    }
}
