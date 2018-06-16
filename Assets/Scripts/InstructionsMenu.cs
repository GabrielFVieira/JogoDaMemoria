using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour {
    public GameObject pressAnyKey;
    private float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
            SceneManager.LoadScene("Game");

        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            pressAnyKey.SetActive(!pressAnyKey.activeSelf);
            timer = 0;
        }
	}
}
