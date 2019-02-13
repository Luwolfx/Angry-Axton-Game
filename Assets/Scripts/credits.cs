using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour {

    public float vel;
    public float tempoParaPassarTela;

	// Use this for initialization
	void Start () {
        StartCoroutine(passartela());
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0, 1 * vel * Time.deltaTime, 0);
	}

    IEnumerator passartela()
    {
        yield return new WaitForSeconds(tempoParaPassarTela);
        SceneManager.LoadScene("Start");
    }
}
