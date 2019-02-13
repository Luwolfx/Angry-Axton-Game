using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Botoes : MonoBehaviour {
    public static bool continuar_ativado = false;
    public GameObject Bt_continuar;
    public GameObject Bt_continuar_disabled;

    private void Update()
    {
        if (continuar_ativado)
        {
            Bt_continuar.SetActive(true);
            Bt_continuar_disabled.SetActive(false);
        }
        else
        {
            Bt_continuar.SetActive(false);
            Bt_continuar_disabled.SetActive(true);
        }
    }

    public void IniciarGame()
    {
        SceneManager.LoadScene(2);
    }
}
