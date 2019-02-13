using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    public GameObject a_Damage;

	// Use this for initialization
	void Start () {
        a_Damage = GameObject.Find("Audio_TakingDamage");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player.vidas--;
            a_Damage.GetComponent<AudioSource>().Play();
        }
    }
}
