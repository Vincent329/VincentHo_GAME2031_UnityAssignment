using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineReset : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Chain chain;
    [SerializeField] private LayerMask check; // set this in the inspector

    [SerializeField] private PlayerMovement m_playerPoints;
    [SerializeField] private GameOverText m_GameManager;


    void Start()
    {
        chain = FindObjectOfType<Chain>();
        m_playerPoints = FindObjectOfType<PlayerMovement>();
        m_GameManager = FindObjectOfType<GameOverText>();
    }

    // Reset the chain on trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        chain.SetIsFired(false);

        // call the split ball function if this chain hits the ball
        if (check.value == 1 << collision.gameObject.layer)
        {
            collision.GetComponent<Ball>().Split();
            
        }
    }
  
}
