using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineReset : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Chain chain;

    void Start()
    {
        chain = FindObjectOfType<Chain>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        chain.SetIsFired(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Contact");
    }
}
