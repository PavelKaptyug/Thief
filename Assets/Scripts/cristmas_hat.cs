using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cristmas_hat : MonoBehaviour
{
    public GameController script;
    public GameObject hat, win_hat, lose_hat;
    void Start()
    {
        win_hat.SetActive(false);
        lose_hat.SetActive(false);
    }

    void Update()
    {
        if (script.win == true)
        {
            hat.SetActive(false);
            win_hat.SetActive(true);
        }
        if (script.lose == true)
        {
            hat.SetActive(false);
            lose_hat.SetActive(true);
        }
    }
}
