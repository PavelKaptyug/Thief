using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish_stickman_sprite : MonoBehaviour
{
    public SpriteRenderer sprite;
    public int win_layer, lose_layer;
    public GameController script;
    public bool tv;
    private handMover hand;
    void Start()
    {
        hand = GameObject.Find("hand").GetComponent<handMover>();
    }

    void Update()
    {
        if (script.win == true)
            sprite.sortingOrder = win_layer;

        if (script.lose == true)
            sprite.sortingOrder = lose_layer;
        if(tv==true)
            if(hand.finished_==true)
                sprite.sortingOrder = win_layer;
    }
}
