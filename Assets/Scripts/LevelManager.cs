using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public GameManager game;
	public GameObject soundButton;
    public AudioSource song;
	public Sprite sound;
	public Sprite mute;
	// Use this for initialization
	void Start () {
		game = GameObject.FindGameObjectWithTag ("Manager").GetComponent<GameManager>();

		if (game.sound == true)
			soundButton.GetComponent<Image>().sprite = sound;

		else
			soundButton.GetComponent<Image>().sprite = mute;
	}
	
	// Update is called once per frame
	void Update () {
        if (game.sound == true)
        {
            soundButton.GetComponent<Image>().sprite = sound;
            song.volume = 1;
        }

        if(game.sound == false)
        {
            soundButton.GetComponent<Image>().sprite = mute;
            song.volume = 0;
        }
	}

	public void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void Sound()
	{
		game.sound = !game.sound;
	}

	public void Menu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
