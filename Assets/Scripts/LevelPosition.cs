using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPosition : MonoBehaviour
{
    public RectTransform transform;
    void Start()
    {
        if (PlayerPrefs.GetInt("levelsComplete") > 60)
            transform.anchoredPosition = new Vector3(0, 306 * ((PlayerPrefs.GetInt("levelsComplete") - 58) / 3), 0);
        if (PlayerPrefs.GetInt("levelsComplete") < 43)
            transform.anchoredPosition = new Vector3(0, 306 * ((PlayerPrefs.GetInt("levelsComplete") - 45) / 3), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
