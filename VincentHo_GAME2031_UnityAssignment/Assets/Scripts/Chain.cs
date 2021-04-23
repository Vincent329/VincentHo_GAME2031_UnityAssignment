using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform playerPos;

    // here so that we don't need a direct reference to this particular script
    [SerializeField] private bool isFired;
    [SerializeField] public SpriteRenderer chainSprite;
    void Start()
    {
        isFired = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (isFired)
        {

        } 
        else
        {
            transform.position = playerPos.position;
            transform.localScale = new Vector3(1.0f, 0.0f, 1.0f); // keeps the scale of the pivot to 0, won't be visible
        }
    }

    public void SetIsFired(bool fired)
    {
        isFired = fired;
        Debug.Log(isFired);
    }
}
