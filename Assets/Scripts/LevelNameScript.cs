using Eiko.YaSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelNameScript : MonoBehaviour
{
    public string test;
    [SerializeField] private Text textName;
    public string[] lang = { "en", "ru", "pt", "es", "ar", "hi", "tr", "ja", "fr", "id", "de", "it", "zh" };
    private string[] level_name = { "Level", "Уровень", "Nível", "Nivel", "", "लेवल", "Seviye", "レベル", "Niveau", "Level", "Level", "Livello", "等级" };
    private string[] all_level_name = { "Levels", "Уровни", "Níveis", "Niveles", "المستويات", "लेवल", "Seviyeler", "レベル", "Niveaux", "Level", "Level", "Livelli", "关卡" };
    public int[] font_size = { 200, 140, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200 };
    public int lang_i;
    public bool all_levels;
    public Font eng_font, ru_font, pt_font, es_font, ar_font, hi_font, tr_font, ja_font, fr_font, id_font, de_font, it_font, zh_font;
    private void Start()
    {
        var text = SceneManager.GetActiveScene().buildIndex;
        Font[] fonts = { eng_font, ru_font, pt_font, es_font, ar_font, hi_font, tr_font, ja_font, fr_font, id_font, de_font, it_font, zh_font };
        test = YandexSDK.instance.Lang;
        Debug.Log(test);
        //test = "zh";
        FindI();
        textName.font =fonts[lang_i];
        if (all_levels == false)
        {
            if (test != "ar")
            {
                textName.text = (level_name[lang_i]+" " + text.ToString()).ToString();
            }
            else
            {
                textName.text = (text.ToString()+" " + "المستوى").ToString();
            }
        }
        else
        {
            textName.text = all_level_name[lang_i];
        }
    }
    public void FindI()
    {
        for (int j = 0; j < 13; j++)
            if (test== lang[j])
            {
                lang_i = j;
                j = 13;
            }
    }
}
