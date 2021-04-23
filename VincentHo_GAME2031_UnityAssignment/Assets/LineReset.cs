using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineReset : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Chain chain;
    [SerializeField] private LayerMask check; // set this in the inspector

    void Start()
    {
        chain = FindObjectOfType<Chain>();
    }

    // Reset the chain on trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        chain.SetIsFired(false);

        if (check.value == 1 << collision.gameObject.layer)
        {
            Debug.Log("HitBall");
            collision.GetComponent<Ball>().Split();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Contact");
    }
}
