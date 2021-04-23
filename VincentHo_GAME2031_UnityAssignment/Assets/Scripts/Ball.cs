using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 m_StartForce;
    [SerializeField] private int m_PointValue;
    // spawn the next 2 copies of whatever ball we want to place in here
    [SerializeField] private GameObject m_nextBall;

    [SerializeField] private PlayerMovement m_PlayerRef;

    private Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.AddForce(m_StartForce, ForceMode2D.Impulse);
        m_PlayerRef = FindObjectOfType<PlayerMovement>();
    }

    // make public to make the chain detect it
    public void Split()
    {
        // if there's another ball to spawn
        if (m_nextBall != null)
        {
            GameObject ballRight = Instantiate(m_nextBall, m_rb.position + Vector2.right / 2f, Quaternion.identity);
            GameObject ballLeft = Instantiate(m_nextBall, m_rb.position + Vector2.left / 2f, Quaternion.identity);

            ballRight.GetComponent<Ball>().m_StartForce = new Vector2(2.0f, 5.0f);
            ballLeft.GetComponent<Ball>().m_StartForce = new Vector2(-2.0f, 5.0f);
        }
        m_PlayerRef.UpdatePoints(m_PointValue);
        Destroy(gameObject);
    }

    public int GetPointValue()
    {
        return m_PointValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
