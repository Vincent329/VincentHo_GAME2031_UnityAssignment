using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D m_rb; 

    [SerializeField]
    bool bIsFiring;

    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    private GameObject gObject;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    private void FixedUpdate()
    {
        
    }

    private void HandleInputs()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Vector2 tpos = Camera.main.ScreenToWorldPoint(t.position);
            if (t.phase == TouchPhase.Began)
            Instantiate(gObject, tpos, Quaternion.identity);
        }
    }
    
}
