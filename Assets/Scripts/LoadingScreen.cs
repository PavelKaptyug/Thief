using Eiko.YaSDK.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Animator animator;
    public static bool isInit=false;
    private IEnumerator Start()
    {
        if(!isInit)
        {
            //InitHer
            yield return YandexPrefs.Init();
            //EndInit
            isInit=true;
        }
        animator.SetTrigger("Play");
    }
}
