using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class face : MonoBehaviour
{
    public handMover hand_script;
    public int finish_layer;
    public SpriteRenderer sprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hand_script.finished_ == true)
            sprite.sortingOrder = finish_layer;
    }
}
