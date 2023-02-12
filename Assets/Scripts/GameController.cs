using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Eiko.YaSDK;
using Eiko.YaSDK.Data;

public class GameController : MonoBehaviour
{
    public Sprite PlLoseSp, PlWinSp;
    public SpriteRenderer player;
    public Sprite ManLoseSp, ManWinSp;
    public Sprite Man2LoseSp, Man2WinSp;
    public SpriteRenderer man;
    public SpriteRenderer man2;

    public LineRenderer line_RendererComp;
    public GameObject line;
    public handMover hand_Mover;
    public SpriteRenderer hand;
    public GameObject manObj;
    public GameObject manObj2;
    Vector3 hatWinOffcet;
    Vector3 hatLoseOffcet;
    public Transform hat;
    public Transform hat2;

    public bool winScale;
    public bool loseScale;
    public string pers;
    public string hatType;
    public int numPers = 1;
    public GameObject endGameDisplay;
    public Text endScreenText;
    private string[] endLosePhrases= { "Don't give up!", "Do it again!", "Go on, you can do it!" };
    private string[] endWinPhrases= { "Perfect!", "Excellent!" };
    private string[] ru_endLosePhrases = { "Не сдавайся!", "Попробуй еще раз!", "У тебя получится!" };
    private string[] ru_endWinPhrases = {"Прекрасно!", "Великолепно!" };
    private string[] pt_endLosePhrases = { "Faz de novo", "Vá lá, tu podes", "Não desistas!" };
    private string[] pt_endWinPhrases = { "Perfeito!", "Excelente!" };
    private string[] es_endLosePhrases = { "Hazlo de nuevo", "Venga, que tú puedes", "¡No te rindas!" };
    private string[] es_endWinPhrases = { "Perfecto", "¡Excelente!" };
    private string[] ar_endLosePhrases = { "لا تستلم!", "افعلها مرة أخرى", "واصل، يمكنك النجاح" };
    private string[] ar_endWinPhrases = { "ممتاز", "رائع!" };
    private string[] hi_endLosePhrases = { "हार न मानें!", "फिर से करें", "करें, आप कर सकते हैं" };
    private string[] hi_endWinPhrases = { "सबसे अच्छा", "बहुत ही शानदार!" };
    private string[] tr_endLosePhrases = { "Pes etme!", "Tekrar yap", "Hadi, yapabilirsin" };
    private string[] tr_endWinPhrases = { "Mükemmel!", "Mükemmel!" };
    private string[] ja_endLosePhrases = { "あきらめないで！", "もう一度がんばろう", "次はきっとできるよ" };
    private string[] ja_endWinPhrases = { "パーフェクト", "素晴らしい！" };
    private string[] fr_endLosePhrases = { "N'abandonnez pas !", "Recommencez !", "Vous pouvez le faire !" };
    private string[] fr_endWinPhrases = { "Parfait !", "Excellent !" };
    private string[] id_endLosePhrases = { "Jangan menyerah!", "Coba lagi", "Ayo, kamu pasti bisa" };
    private string[] id_endWinPhrases = { "Sempurna", "Luar biasa!" };
    private string[] de_endLosePhrases = { "Nicht aufgeben!", "Nochmal!", "Oh oh, du schaffst das!" };
    private string[] de_endWinPhrases = { "Perfekt", "Ausgezeichnet!" };
    private string[] it_endLosePhrases = { "Non arrenderti!", "Riprovaci", "Forza, puoi farcela" };
    private string[] it_endWinPhrases = { "Perfetto", "Eccellente!" };
    private string[] zh_endLosePhrases = { "别放弃", "再来一次", "加油，你行的" };
    private string[] zh_endWinPhrases = { "完美", "太棒了！" };
    public GameObject hint;
    public GameObject playerObj;
    public GameObject cop;
    public bool playerScale;
    public GameObject car;
    bool isWin = false;
    bool isLose = false;
    public LevelNameScript lang;
    public Font eng_font, ru_font, pt_font, es_font, ar_font, hi_font, tr_font, ja_font, fr_font, id_font, de_font, it_font, zh_font;
    public bool win, lose;

    public AudioSource winSound, loseSound;

    public void Start()
    {
        var lvl = YandexPrefs.GetInt("levelsComplete");
        if(lvl>0&&lvl<21)
            AppMetricaWeb.Event("lvl"+lvl);
        AppMetricaWeb.Event("roundStartUniversal");
        Eiko.YaSDK.YandexSDK.instance.FOR_INTER();
        isWin = false;
        isLose = false;
        Time.timeScale = 1;
        if (hat != null || hat2 != null)
        {
            if (pers == "man")
            {
                hatWinOffcet = new Vector3(-0.49f, 0, 0);
                hatLoseOffcet = new Vector3(2.25f, -0.3f, 0);
                if (hatType == "hair")
                {
                    hatLoseOffcet = new Vector3(1.82f, -0.5f, 0);
                }
            }
            if (pers == "woman")
            {
                hatWinOffcet = new Vector3(-0.7f, 0.1f, 0);
                hatLoseOffcet = new Vector3(-2.33f, 0, 0);
                if (hatType == "hat")
                {
                    hatWinOffcet = new Vector3(0.61f, -0.3f, 0);
                    hatLoseOffcet = new Vector3(2.5f, 0, 0);
                }
                else if (hatType == "longHat")
                {
                    hatWinOffcet = new Vector3(0.61f, -0.3f, 0);
                    hatLoseOffcet = new Vector3(2.03f, -0.5f, 0);
                }
                else if (hatType == "hair")
                {
                    hatWinOffcet = new Vector3(0.67f, -0.1f, 0);
                    hatLoseOffcet = new Vector3(2.02f, -0.4f, 0);
                }
            }
        }
    }
    /*
    public void WinSound()
    {
        isWin = false;
        winSound.Play();
    }
    */
    public void Win()
    {
        if (isLose != true && isWin != true)
        {
            StartCoroutine(waitWin());
            isWin = true;
        }
    }
    IEnumerator waitWin()
    {
        string[][] win_phrases = { endWinPhrases, ru_endWinPhrases,pt_endWinPhrases,es_endWinPhrases,ar_endWinPhrases,hi_endWinPhrases,tr_endWinPhrases,ja_endWinPhrases,fr_endWinPhrases,id_endWinPhrases,de_endWinPhrases,it_endWinPhrases,zh_endWinPhrases };
        Font[] fonts = { eng_font, ru_font, pt_font, es_font, ar_font, hi_font, tr_font, ja_font, fr_font, id_font, de_font, it_font, zh_font };
        winSound.Play();
        yield return new WaitForSeconds(1);
        win = true;
        if (hat != null)
            hat.position = hat.position + hatWinOffcet;
        Destroy(line.GetComponent<Collider2D>());
        Destroy(hand.GetComponent<Collider2D>());
        if (winScale)
            manObj.transform.localScale = new Vector3(manObj.transform.localScale.x * -1, manObj.transform.localScale.y, manObj.transform.localScale.z);
        player.sprite = PlWinSp;
        man.sprite = ManWinSp;
        if (man2 != null)
            man2.sprite = Man2WinSp;
        hand.enabled = false;
        line_RendererComp.enabled = false;
        if (numPers == 2)
        {
            //man2.sprite = ManWinSp;
            if (hat2 != null)
                hat2.position = hat2.position + hatWinOffcet;
            if (winScale)
                manObj2.transform.localScale = new Vector3(manObj2.transform.localScale.x * 1, manObj2.transform.localScale.y, manObj2.transform.localScale.z);
            else
                manObj2.transform.localScale = new Vector3(manObj2.transform.localScale.x * -1, manObj2.transform.localScale.y, manObj2.transform.localScale.z);
        }

        var random = new System.Random();
        var index = random.Next(0, endWinPhrases.Length);
        lang.FindI();
        endScreenText.fontSize = lang.font_size[lang.lang_i];
        endScreenText.font = fonts[lang.lang_i];
        endScreenText.text =win_phrases[lang.lang_i][index];
        endGameDisplay.SetActive(true);
        
        hint.SetActive(false);
        if (playerObj != null)
        {
            if (playerScale)
            {
                playerObj.transform.localScale = new Vector3(playerObj.transform.localScale.x * -1, playerObj.transform.localScale.y, playerObj.transform.localScale.z);
            }
        }
        if (YandexPrefs.GetInt("levelsComplete") < SceneManager.GetActiveScene().buildIndex)
            YandexPrefs.SetInt("levelsComplete", YandexPrefs.GetInt("levelsComplete") + 1);
        if (car != null)
            car.SetActive(false);
        Time.timeScale = 0;
        /*if (PlayerPrefs.GetInt("levelsComplete") >= 10 && (PlayerPrefs.GetInt("levelsComplete")) % 5 == 0)
            YandexSDK.instance.FOR_REWIE();*/
    }
    public void Lose()
    {
        AppMetricaWeb.Event("roundEnd");
        if (isLose != true && isWin != true)
        {
            //Eiko.YaSDK.YandexSDK.instance.FOR_INTER();
            StartCoroutine(waitLose());
            loseSound.Play();
            isLose = true;
            hand_Mover.lose = true;
        }
    }
    IEnumerator waitLose()
    {
        string[][] lose_phrases = { endLosePhrases, ru_endLosePhrases,pt_endLosePhrases,es_endLosePhrases,ar_endLosePhrases,hi_endLosePhrases,tr_endLosePhrases,ja_endLosePhrases,fr_endLosePhrases,id_endLosePhrases,de_endLosePhrases,it_endLosePhrases,zh_endLosePhrases };
        Font[] fonts = { eng_font, ru_font, pt_font, es_font, ar_font, hi_font, tr_font, ja_font, fr_font, id_font, de_font, it_font, zh_font };
        yield return new WaitForSeconds(1);
        lose = true;
        if (hat != null)
            hat.position = hat.position + hatLoseOffcet;
        Destroy(line.GetComponent<Collider2D>());
        Destroy(hand.GetComponent<Collider2D>());
        player.sprite = PlLoseSp;
        man.sprite = ManLoseSp;
        if (man2 != null)
            man2.sprite = Man2LoseSp;
        hand.enabled = false;
        line_RendererComp.enabled = false;
        hint.SetActive(false);
        var random = new System.Random();
        var index = random.Next(0, endLosePhrases.Length);
        lang.FindI();
        endScreenText.fontSize = lang.font_size[lang.lang_i];
        endScreenText.font = fonts[lang.lang_i];
        endScreenText.text = lose_phrases[lang.lang_i][index];
        endGameDisplay.SetActive(true);
        if (playerObj != null)
        {
            if (playerScale)
            {
                playerObj.transform.localScale = new Vector3(playerObj.transform.localScale.x * -1, playerObj.transform.localScale.y, playerObj.transform.localScale.z);
            }
        }
        if (cop != null)
            cop.SetActive(true);
        if (car != null)
            car.SetActive(false);
        Time.timeScale = 0;
        /*if (PlayerPrefs.GetInt("levelsComplete")+1 >= 10 && (PlayerPrefs.GetInt("levelsComplete")+1)% 5 == 0)
                YandexSDK.instance.FOR_REWIE();*/
        YandexSDK.instance.ShowInterstitial();
    }
}
