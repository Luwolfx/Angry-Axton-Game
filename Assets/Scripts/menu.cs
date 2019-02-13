using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    public bool MainMenu, MenuPause;
    private bool click;
    public float posicao;

    public static bool unPause = false;

    //Audios
    private GameObject a_ClickActive;
    private GameObject a_ClickUnable;
    private GameObject a_ChangeOption;

    //Components
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        a_ClickActive = GameObject.Find("Audio_ClickActivated");
        a_ClickUnable = GameObject.Find("Audio_ClickUnable");
        a_ChangeOption = GameObject.Find("Audio_ChangeOption");
        click = false;
    }

    // Update is called once per frame
    void Update () {
        posicao = transform.position.y;

        if(MainMenu && !MenuPause)
        {
            OnMenu();
        }
        else if (!MainMenu && MenuPause)
        {
            OnPause();
        }

        //Animations
        anim.SetBool("Click", click);
	}

    void OnMenu()
    {
        if (MainMenu & !MenuPause & !click)
        {
            if (posicao == 0.078f)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.position = new Vector2(transform.position.x, -2.92f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.position = new Vector2(transform.position.x, -1.39f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
            }
            if (posicao == -1.39f)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.position = new Vector2(transform.position.x, 0.078f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.position = new Vector2(transform.position.x, -2.92f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
            }
            if (posicao == -2.92f)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.position = new Vector2(transform.position.x, -1.39f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.position = new Vector2(transform.position.x, 0.078f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
            }
        }

        if (Input.GetButtonDown("Submit") && !click)
        {
            if (posicao == 0.078f)
            {
                StartCoroutine(Startgame(2));
                a_ClickActive.GetComponent<AudioSource>().Play();
                click = true;
            }
            if (posicao == -1.39f)
            {
                if (Botoes.continuar_ativado)
                {
                    StartCoroutine(ContinueGame(2));
                    a_ClickActive.GetComponent<AudioSource>().Play();
                    click = true;
                }
                else
                {
                    a_ClickUnable.GetComponent<AudioSource>().Play();
                    print("SAVE NÃO ENCONTRADO");
                }
            }
            if (posicao == -2.92f)
            {
                StartCoroutine(Credits(2));
                a_ClickActive.GetComponent<AudioSource>().Play();
                click = true;
            }
        }
    }

    void OnPause()
    {
        if (!MainMenu & MenuPause & !click)
        {
            if (posicao == 2.2f)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.position = new Vector2(transform.position.x, 0.55f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.position = new Vector2(transform.position.x, 1.4f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
            }
            if (posicao == 1.4f)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.position = new Vector2(transform.position.x, 2.2f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.position = new Vector2(transform.position.x, 0.55f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
            }
            if (posicao == 0.55f)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.position = new Vector2(transform.position.x, 1.4f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.position = new Vector2(transform.position.x, 2.2f);
                    a_ChangeOption.GetComponent<AudioSource>().Play();
                }
            }
        }
        if (Input.GetButtonDown("Submit") && !click)
        {
            if (posicao == 2.2f)
            {
                a_ClickActive.GetComponent<AudioSource>().Play();
                unPause = true;
            }
            if (posicao == 1.4f)
            {
                a_ClickUnable.GetComponent<AudioSource>().Play();
            }
            if (posicao == 0.55f)
            {
                a_ClickActive.GetComponent<AudioSource>().Play();
                Time.timeScale = 1;
                StartCoroutine(QuitGame(1));
                click = true;
            }
        }
    }

    IEnumerator Startgame(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(2);
    }
    IEnumerator ContinueGame(float y)
    {
        yield return new WaitForSeconds(y);
        SceneManager.LoadScene(2);
    }
    IEnumerator Credits(float u)
    {
        yield return new WaitForSeconds(u);
        SceneManager.LoadScene("Credits");
    }
    IEnumerator Continue(float i)
    {
        yield return new WaitForSeconds(i);
        unPause = true;
    }
    IEnumerator QuitGame(float o)
    {
        yield return new WaitForSeconds(o);
        SceneManager.LoadScene(1);
    }

}
