using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour {

    public GameObject personagem;
    public float velocidade;
    public float limite;
    public bool vertical;
    

	void Start () {
        personagem = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        // Calcula a distancia entre a camera e o personagem
        float distancia = Vector3.Distance(personagem.transform.position, transform.position);

        //VERIFICA SE É UMA FASE VERTICAL
        if (vertical)
        {
            if (distancia > limite)
            {
                Vector3 posicao = new Vector3(personagem.transform.position.x, (personagem.transform.position.y + 2.5f), transform.position.z);
                transform.position = Vector3.Lerp(transform.position, posicao, velocidade * Time.deltaTime);
            }
        }
        else
        {
            //VERIFICA SE O PERSONAGEM ESTA OLHANDO PRA DIREITA OU PARA ESQUERDA
            if (Player.dir)
            {
                if (distancia > limite)
                {
                    Vector3 posicao = new Vector3((personagem.transform.position.x + 3.5f), transform.position.y, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, posicao, velocidade * Time.deltaTime);
                }
            }
            else if (Player.esq)
            {
                if (distancia > limite)
                {
                    Vector3 posicao = new Vector3((personagem.transform.position.x - 3.5f), transform.position.y, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, posicao, velocidade * Time.deltaTime);
                }
            }
        }
	}
}
