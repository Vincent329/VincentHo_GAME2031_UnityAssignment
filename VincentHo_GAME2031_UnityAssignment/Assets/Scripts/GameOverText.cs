using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverText : MonoBehaviour
{
    [SerializeField] private bool isGameOver;

    [SerializeField] private TextMeshProUGUI m_GameOverText;
    [SerializeField] private TextMeshProUGUI m_FinalScoreText;
    [SerializeField] private TextMeshProUGUI m_NotifText;

    // Start is called before the first frame update
    void Start()
    {
        m_GameOverText.enabled = false;
        m_FinalScoreText.enabled = false;   
        m_NotifText.enabled = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            HandleInput();
        }
    }

    public void DisplayFinalScore(int value)
    {
        m_GameOverText.enabled = true;
        m_FinalScoreText.enabled = true;
        m_NotifText.enabled = true;
        isGameOver = true;
        m_FinalScoreText.text = "Final Score: " + value;
    }

    private void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            SceneManager.LoadScene("MainGame");
        }
    }


}
