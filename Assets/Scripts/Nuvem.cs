using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuvem : MonoBehaviour {

    public float velocidade;
    public float limite;
    public float retornar;
    public bool dir, esq;

	// Use this for initialization
	void Start () {
        retornar = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

        if (dir)
        {
            transform.Translate(velocidade * 1 * Time.deltaTime, 0, 0);

            if(transform.position.x > limite)
            {
                transform.position = new Vector2(retornar, transform.position.y);
            }
        }
        else if (esq)
        {
            transform.Translate(velocidade * -1 * Time.deltaTime, 0, 0);

            if(transform.position.x < limite)
            {
                transform.position = new Vector2(retornar, transform.position.y);
            }
        }
	}
}
