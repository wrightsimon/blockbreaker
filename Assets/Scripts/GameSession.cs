using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    //Configuration Parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 5;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool autoPlay;

    //State Variables
    [SerializeField] int currentScore = 0; //Serialized for debug purposes.

    //Awake is called before Start
    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            ResetGame();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return autoPlay;
    }
}
