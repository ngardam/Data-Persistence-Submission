using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIHandler : MonoBehaviour
{
    public void StartGameButton()
    {
        MainManager.Instance.StartGameButton();
    }

    public void ExitGameButton()
    {
        MainManager.Instance.ExitGameButton();
    }
}
