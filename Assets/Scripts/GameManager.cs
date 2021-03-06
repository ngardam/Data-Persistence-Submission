using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{



    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public string playerName;

    public Text ScoreText;

    [SerializeField] Text highScoreText;

    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;

    const float step = 0.6f;

    private float startingBallForce = 2.0f;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
       // UpdateHighScore();
        playerName = MainManager.Instance.playerName;
        UpdateHighScore();
        LoadLevel();
        AddPoint(0);
        
        //  const float step = 0.6f;
        //  int perLine = Mathf.FloorToInt(4.0f / step);
        //  
        //  int[] pointCountArray = new [] {1,1,2,2,5,5};
        //  for (int i = 0; i < LineCount; ++i)
        //  {
        //      for (int x = 0; x < perLine; ++x)
        //      {
        //          Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
        //          var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
        //          brick.PointValue = pointCountArray[i];
        //          brick.onDestroyed.AddListener(AddPoint);
        //      }
        //  }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;

                Vector3 forceDir = RandomForceDirection();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * startingBallForce, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private Vector3 RandomForceDirection()
    {
        float randomDirection = Random.Range(-1.0f, 1.0f);
        Vector3 forceDir = new Vector3(randomDirection, 1, 0);
        forceDir.Normalize();
        return forceDir;
    }

    private void LoadLevel()
    {
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

  //  private void StartGame()
  //  {
  //
  //  }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Name: " + playerName + " Score: " + m_Points;
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        SubmitScore(playerName, m_Points);
        UpdateHighScore();

    }

    private void SubmitScore(string _name, int score)
    {
        MainManager.Instance.SubmitScore(_name, score);
    }

  //  public void StartGameButton()
  //  {
  //      SceneManager.LoadScene(1);
  //
  //      //  Ball = GameObject.Find("Ball").GetComponent<Rigidbody>();
  //      //  if (Ball == null)
  //      //  {
  //      //      Debug.Log("No ball found");
  //      //  }
  //      //  ScoreText = GameObject.Find("Score Text").GetComponent<Text>();
  //
  //  }

    public void MainMenuButton()
    {
        MainManager.Instance.MainMenuButton();
    }


    public void UpdateHighScore()
    {
        (string, int) _highscore = MainManager.Instance.highScores[0];

        highScoreText.text = "Best Score: " + _highscore.Item1 + "  " + _highscore.Item2;
    }
}
