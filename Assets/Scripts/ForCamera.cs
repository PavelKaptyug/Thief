using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI    ;

public class ForCamera : MonoBehaviour
{
    public Camera camera;
    void Start()
    {
        camera.rect = new Rect(0,0,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        camera.rect = new Rect(0, 0, 1, 1);

    }
}
