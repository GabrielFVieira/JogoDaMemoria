using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public LanguageManager language;

    public Sprite[] bg;
    public Sprite[] voltar;

    public Image[] itens;
    // Use this for initialization
    void Start()
    {
        language = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        itens[0].sprite = bg[language.language];
        itens[1].sprite = voltar[language.language];
    }

    public void back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Portugues()
    {
        language.language = 0;
    }

    public void Ingles()
    {
        language.language = 1;
    }

    public void Espanhol()
    {
        language.language = 2;
    }
}