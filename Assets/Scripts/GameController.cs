using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool IsGamePaused = false;
    public static bool playerJogando = true;
    public static bool startconversation = true;

    public GameObject pauseMenu_Sprite;
    public GameObject pauseMenu_Canvas;
    public GameObject pauseMenu_Arrow;

    //Audios
    private GameObject a_BgMusic;

	// Use this for initialization
	void Start () {
        IsGamePaused = false;
        playerJogando = true;
        startconversation = true;

        a_BgMusic = GameObject.Find("Audio_BgMusic");

    }
	
	// Update is called once per frame
	void Update () {
        GamePaused();
	}

    void GamePaused()
    {
        if (IsGamePaused)
        {
            playerJogando = false;
            Unpause();
        }
        else
        {
            playerJogando = true;
            if (Input.GetButtonDown("Submit") && Conversations.playerJogando)
            {
                IsGamePaused = true;
                pauseMenu_Canvas.SetActive(true);
                pauseMenu_Sprite.SetActive(true);
                pauseMenu_Arrow.SetActive(true);
                a_BgMusic.GetComponent<AudioSource>().Pause();
                Time.timeScale = 0;
            }
        }
    }

    void Unpause()
    {
        if (menu.unPause)
        {
            IsGamePaused = false;
            pauseMenu_Canvas.SetActive(false);
            pauseMenu_Sprite.SetActive(false);
            pauseMenu_Arrow.SetActive(false);
            a_BgMusic.GetComponent<AudioSource>().UnPause();
            Time.timeScale = 1;
            menu.unPause = false;
        }
    }
}
