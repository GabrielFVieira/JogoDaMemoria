using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardClick : MonoBehaviour {
    public Sprite normal;
    public Sprite cliked;
    public Sprite hover;

    public Manager manager;

    public bool reflip;

    public bool cardClicked;

	public float timer;

    public bool position;
    // Use this for initialization
    void Start()
    {
        GetComponent<Animator>().enabled = false;
        manager = GameObject.Find("CardsManager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.cardsActived == 0)
        {
            //transform.localScale = new Vector3(1, 1, 1);
            cardClicked = false;
        }

		if (reflip == true) {
			GetComponent<Animator>().enabled = true;
			timer += Time.deltaTime;

			if (timer > 0 && timer < 0.3f) {
				GetComponent<Image> ().sprite = cliked;
			}

			else
				GetComponent<Image>().sprite = normal;

			//transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
		}

		if(reflip == true && timer > 0.2f && transform.localScale.x <= -0.9f)
        {
			

            transform.localScale = new Vector3(1, 1, 1);
			GetComponent<Animator>().enabled = false;
            reflip = false;
			timer = 0;
        }

        if (cardClicked == true && transform.localScale.x >= -0.9f)
        {
            GetComponent<Animator>().enabled = true;

            if(transform.localScale.x < 0)
                GetComponent<Image>().sprite = cliked;
        }

		if(transform.localScale.x < -0.9f && GetComponent<Image>().sprite == cliked && reflip == false)
        {
            GetComponent<Animator>().enabled = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }

			GetComponent<Button> ().interactable = !GetComponent<Animator> ().isActiveAndEnabled;


    }

    public void Clicked()
    {
		if (cardClicked == false && manager.cardsActived < 2  && GetComponent<Animator>().isActiveAndEnabled == false)
        {
            GetComponent<Image>().sprite = normal;
            manager.cardsActived += 1;
            cardClicked = true;
        }
    }

    public void HoverEnter()
    {
		if (cardClicked == false && manager.cardsActived < 2 && GetComponent<Animator>().isActiveAndEnabled == false)
            GetComponent<Image>().sprite = hover;
    }

    public void HoverExit()
    {
		if(cardClicked == false && manager.cardsActived < 2  && GetComponent<Animator>().isActiveAndEnabled == false)
        GetComponent<Image>().sprite = normal;
    }
}
