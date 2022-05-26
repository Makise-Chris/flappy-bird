using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject gameOverPanel;

    private void Awake()
    {
        _makeInstance();
    }
    void _makeInstance()
    {
        if(instance == null) instance = this;
    }
    
    public void _setScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void _showPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void _toMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void _restart()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
