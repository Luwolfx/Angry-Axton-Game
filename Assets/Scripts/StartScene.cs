using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour {

    public GameObject text;
    private float intervalo_desaparecimento = 1f;
    private float intervalo_aparecimento = 0.5f;
    public bool StartInput;

    private GameObject a_ClickActive;


	// Use this for initialization
	void Start () {
        text = GameObject.Find("Text_pressAnyButton");
        a_ClickActive = GameObject.Find("Audio_ClickActivated");
        StartCoroutine(Textdesapear(intervalo_desaparecimento));
	}
	
	// Update is called once per frame
	void Update () {
        if (StartInput)
        {
            if (Input.GetButtonDown("Submit"))
            {
                a_ClickActive.GetComponent<AudioSource>().Play();
                SceneManager.LoadScene("Menu");
            }
        }
	}

    IEnumerator Textdesapear(float t)
    {
        yield return new WaitForSeconds(t);

        text.SetActive(false);

        StartCoroutine(Textapear(intervalo_aparecimento));
        StartCoroutine(Textdesapear(intervalo_desaparecimento));
    }

    IEnumerator Textapear(float t)
    {
        yield return new WaitForSeconds(t);
        text.SetActive(true);
    }
}
