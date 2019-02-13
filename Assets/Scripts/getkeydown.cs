using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class getkeydown : MonoBehaviour {

    public bool menu;
    public bool game;
    public bool start;
    public bool credits;
    public bool gameover;

    // Update is called once per frame
    void Update () {
        if (menu)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (game)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Game");
            }
        }
        if (start)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Start");
            }
        }
        if (credits)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Credits");
            }
        }
        if (gameover)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Gameover");
            }
        }
	}
}
