using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int ballCount;
    // Start is called before the first frame update
    public void loadMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateBallCount()
    {
        ballCount = GameObject.FindObjectsOfType(typeof(Ball)).Length;
        Debug.Log(ballCount);
    }
}
