using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public LanguageManager language;

    public Sprite[] play;
    public Sprite[] options;
    public Sprite[] credits;
    public Sprite[] exit;

    public Image[] buttons;
	// Use this for initialization
	void Start ()
    {
        language = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        buttons[0].sprite = play[language.language];
        buttons[1].sprite = options[language.language];
        buttons[2].sprite = credits[language.language];
        buttons[3].sprite = exit[language.language];
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
