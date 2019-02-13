using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    public Text money;
	
	// Update is called once per frame
	void Update () {
        money.text = Player.money.ToString();
	}
}
