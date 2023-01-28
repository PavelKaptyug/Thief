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
            if (targetPos.y > 0.9f){
                script.cliced_ = false;
                hand.position = new Vector3(hand.position.x, 0.8f, hand.position.z);
                hand.rotation = Quaternion.Euler(0, 0, 0);
                StartCoroutine(coll_update()); }
        }
    }
    IEnumerator coll_update()
    {
        coll.enabled = false;
        yield return new WaitForSeconds(0.1f);
        coll.enabled = true;
    }
}
