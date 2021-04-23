using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Vector2 m_StartForce;
    // Start is called before the first frame update
    private Rigidbody2D m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.AddForce(m_StartForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
