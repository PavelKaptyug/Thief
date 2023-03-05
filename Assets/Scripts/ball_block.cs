using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_block : MonoBehaviour
{
    public float distance;
    public Transform hand;
    public Camera cam;
    public handMover script;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance= Vector2.Distance(transform.position, hand.position);
        if (distance <= 2.5f)
        {
            script.cliced_ = false;
        }
    }
}
