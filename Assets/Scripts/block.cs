using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public handMover script;
    public Transform hand;
    public Collider2D coll;
    public Camera cam;
    private Vector3 targetPos;
    public bool level7,level8,level97;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
        //if(targetPos.y<1)
          //  script.cliced_ = true;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "hand")
        {
            Debug.Log("lol");
            if (targetPos.y > 0.9f && level97==true){
                script.cliced_ = false;
                hand.position = new Vector3(hand.position.x, 0.8f, hand.position.z);
                hand.rotation = Quaternion.Euler(0, 0, 0);
                StartCoroutine(coll_update()); }
            else if(level7 == true)
            {
                script.cliced_ = false;
                if(hand.position.x<-2f)
                    hand.position = new Vector3(-3.6f, hand.position.y, hand.position.z);
                else
                {
                    hand.position = new Vector3(1.2f, hand.position.y, hand.position.z);
                }
                hand.rotation = Quaternion.Euler(0, 0, 0);
                StartCoroutine(coll_update());
            }
            else if (level8 == true)
            {
                Debug.Log("lol");
                script.cliced_ = false;
                StartCoroutine(coll_update());
            }
        }
    }
    IEnumerator coll_update()
    {
        coll.enabled = false;
        yield return new WaitForSeconds(0.1f);
        coll.enabled = true;
    }
}
