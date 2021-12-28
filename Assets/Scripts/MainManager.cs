using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;


    private void Awake()
    {
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

 
    private void StartGame()
    {

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

    }
}
