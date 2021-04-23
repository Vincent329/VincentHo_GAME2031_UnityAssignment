using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverText : MonoBehaviour
{
    [SerializeField] private bool isGameOver;
    [SerializeField] private int ballCount;
    [SerializeField] private int finalScore;
    [SerializeField] private TextMeshProUGUI m_WinText;
    [SerializeField] private TextMeshProUGUI m_GameOverText;
    [SerializeField] private TextMeshProUGUI m_FinalScoreText;
    [SerializeField] private TextMeshProUGUI m_NotifText;

    // Start is called before the first frame update
    void Start()
    {
        ballCount = GameObject.FindObjectsOfType(typeof(Ball)).Length;
        Debug.Log(ballCount);

        m_WinText.enabled = false;
        m_GameOverText.enabled = false;
        m_FinalScoreText.enabled = false;   
        m_NotifText.enabled = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBallCount();
        if (ballCount <= 0)
        {
            SetIsGameOver(true);
        }

        if (isGameOver)
        {
            DisplayFinalScore(finalScore);
            HandleInput();
        }
    }

    private void DisplayFinalScore(int value)
    {
        if (ballCount <= 0)
        {
            m_WinText.enabled = true;
        }
        else
        {
            m_GameOverText.enabled = true;
            m_FinalScoreText.enabled = true;
        }

        m_NotifText.enabled = true;
        m_FinalScoreText.text = "Final Score: " + value;
    }

    // allows player to tap the screen to reset the game
    private void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Ended)
            {
                SceneManager.LoadScene("MainGame");
            }
        }
    }

    public void SetFinalScore(int value)
    {
        finalScore = value;
    }

    public void SetIsGameOver(bool value)
    {
        isGameOver = value;
    }

    // public to call from ball class
    public void UpdateBallCount()
    {
        ballCount = GameObject.FindObjectsOfType(typeof(Ball)).Length;
    }

}
