using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limited_time : MonoBehaviour
{
    public float time;
    public SpriteRenderer sprite;
    public Sprite end_sprite,start_sprite;
    public GameController script;
    public Collider2D bag,lose_bag;
    void Start()
    {
        StartCoroutine(TimeToLose());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TimeToLose()
    {
        while (script.lose == false && script.win == false)
        {
            sprite.sprite = end_sprite;
            bag.enabled = false;
            lose_bag.enabled = true;
            yield return new WaitForSeconds(time);
            sprite.sprite = start_sprite;
            bag.enabled = true;
            lose_bag.enabled = false;
            yield return new WaitForSeconds(time);
        }
    }
}
