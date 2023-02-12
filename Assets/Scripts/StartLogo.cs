using Eiko.YaSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartLogo : MonoBehaviour
{
    public GameObject eng_logo,ru_logo,pt_logo, es_logo, ar_logo, hi_logo, tr_logo, ja_logo, fr_logo, id_logo, de_logo, it_logo, zh_logo;
    public string test;
    public string[] lang = { "en", "ru", "pt", "es", "ar", "hi", "tr", "ja", "fr", "id", "de", "it", "zh" };
    private int lang_i=0;
    void Start()
    {
        GameObject[] logos = { eng_logo, ru_logo, pt_logo, es_logo, ar_logo, hi_logo, tr_logo, ja_logo, fr_logo, id_logo, de_logo, it_logo, zh_logo };
        test = YandexSDK.instance.Lang;
        Debug.Log(test);
        //test = "ru";
        FindI();
        logos[lang_i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FindI()
    {
        for (int j = 0; j < 13; j++)
            if (test== lang[j])
            {
                lang_i = j;
                j = 13;
            }
    }
}
