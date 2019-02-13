using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public Transform Bar;
    public GameObject enemyOwner;

	// Use this for initialization
	void Start () {
        transform.position = new Vector2(enemyOwner.transform.position.x, (enemyOwner.transform.position.y + 2.5f));
	}

    private void Update()
    {
        
    }

    public void SetSize(float tamanhoNormal)
    {
        Bar.localScale = new Vector3(tamanhoNormal, 1f);
    }
}
