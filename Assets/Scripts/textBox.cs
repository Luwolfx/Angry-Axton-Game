using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBox : MonoBehaviour {

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public GameObject Player;
    public GameObject Enemy1;


    public static int currentLine;
    public static int endAtLine;

    // Use this for initialization
    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
    }
    private void Update()
    {
        WhoIsTalking();
        theText.text = textLines[currentLine];
    }

    void WhoIsTalking()
    {
        if(currentLine == 0)
        {
            Player.SetActive(true);
            Enemy1.SetActive(false);
        }
        else if (currentLine == 1)
        {
            Player.SetActive(true);
            Enemy1.SetActive(false);
        }
        else if (currentLine == 2)
        {
            Player.SetActive(true);
            Enemy1.SetActive(false);
        }
        else if (currentLine == 3)
        {
            Player.SetActive(false);
            Enemy1.SetActive(true);
        }
        else if (currentLine == 4)
        {
            Player.SetActive(false);
            Enemy1.SetActive(true);
        }
        else if (currentLine == 5)
        {
            Player.SetActive(true);
            Enemy1.SetActive(false);
        }
        else if (currentLine == 6)
        {
            Player.SetActive(false);
            Enemy1.SetActive(true);
        }
        else if (currentLine == 7)
        {

        }
        else if (currentLine == 8)
        {

        }
        else if (currentLine == 9)
        {

        }
        else if (currentLine == 10)
        {

        }
    }
}
