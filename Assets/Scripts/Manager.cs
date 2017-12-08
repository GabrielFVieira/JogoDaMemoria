using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public LanguageManager language;
    public GameObject[] duplas;
    public float[] pos;
    public float[] posPicked;
    public int random;

    public float pX;
    public float pY;

    public int teste = 0;

    public GameObject winPanel;
	public GameObject losePanel;

	public Text text;
    public int cardsActived;

    public float Timer;

    public float showCardTime;

	public int score;
	public int cards;
	public int couples;

	public Text TimerCounter;
	public float gameTime;
	public float currentTimer;

    public string Tempo;
    public string Remain;
   // Use this for initialization
	void Awake()
	{
        	
	}

    void Start() {
		gameTime = 120;
        showCardTime = 1.1f;
		cards = GameObject.FindGameObjectsWithTag("Cards").Length;
        language = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
    }

    // Update is called once per frame
    void Update() {
        if(language.language == 0)
        {
            Tempo = "Tempo: ";
            Remain = "Restam: ";
        }

        else if (language.language == 1)
        {
            Tempo = "Time: ";
            Remain = "Remain: ";
        }

        else
        {
            Tempo = "Tiempo: ";
            Remain = "Se quedan: ";
        }

        for (int i = 0; i < duplas.Length; i++)
        {
            random = Random.Range(0, 20);
            
            if(posPicked[random] == 0)
            {
                pos[random] = teste;
                teste += 1;
                posPicked[random] = 1;
            }

            if (pos[i] == 0 || pos[i] == 6 || pos[i] == 13)
                pX = -322.5f;

            else if (pos[i] == 1 || pos[i] == 7 || pos[i] == 14)
                pX = -215.5f;

            else if (pos[i] == 2 || pos[i] == 8 || pos[i] == 15)
                pX = -108.5f;

            else if (pos[i] == 3 || pos[i] == 9 || pos[i] == 16)
                pX = -0.499939f;

            else if(pos[i] == 4 || pos[i] == 10 || pos[i] == 17)
                pX = 106.5f;

            else if (pos[i] == 5 || pos[i] == 11 || pos[i] == 18)
                pX = 213.5f;

            else
                pX = 320.5f;

            if (pos[i] >= 0 && pos[i] <= 5)
                pY = 142f;

            else if (pos[i] >= 6 && pos[i] <= 12)
                pY = -1f;

            else
                pY = -147.5f;

            duplas[i].GetComponent<RectTransform>().localPosition = new Vector3(pX, pY, 0);
        }

		if(winPanel.activeSelf == false && losePanel.activeSelf == false)
		currentTimer = Mathf.Round(gameTime -= Time.deltaTime);
		
		TimerCounter.text = Tempo + currentTimer.ToString() + " segs";

		if (currentTimer <= 0) 
		{
            losePanel.SetActive(true);
            GetComponent<AudioSource>().enabled = false;

			foreach (GameObject go in duplas)
				go.GetComponent<Button> ().interactable = false;
		}

		couples = (cards / 2) - score;

		text.text = Remain + couples.ToString();

		if (couples == 0 && currentTimer > 0) 
		{
			winPanel.SetActive (true);
            GetComponent<AudioSource>().enabled = false;
            foreach (GameObject go in duplas)
				go.GetComponent<Button> ().interactable = false;
		}

		for(int i = 0; i < duplas.Length; i += 2) {
			if (duplas[i].activeSelf == true) {
				if (duplas[i].GetComponent<CardClick> ().cardClicked == true && duplas [i + 1].GetComponent<CardClick> ().cardClicked == true) {
					Timer += Time.deltaTime;
					showCardTime = 2;
					if (Timer > showCardTime) {
						duplas[i].SetActive (false);
						duplas[i + 1].SetActive (false);
						score += 1;
						cardsActived = 0;
						Timer = 0;
						showCardTime = 1.1f;
					}
				}
			}
		}

		if (cardsActived == 2) {
			Timer += Time.deltaTime;

			if (Timer > showCardTime + 0.1f) {
				foreach (GameObject go in duplas) {
					if (go.GetComponent<CardClick> ().cardClicked == true) {
						go.GetComponent<CardClick> ().reflip = true;
						go.GetComponent<Image> ().sprite = go.GetComponent<CardClick> ().normal;
					}

					cardsActived = 0;
					Timer = 0;
				}
			}
		}

    }
}