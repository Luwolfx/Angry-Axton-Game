using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conversations : MonoBehaviour {


    public bool Conversation = false;
    public static int conversationOrder = 0;
    public int startConversation = 0;
    public int porteiroConversation = 0;

    public static bool playerJogando;

    public GameObject theTextBox;

    public bool finishConversation = false;

    public TextAsset textFile;
    public string[] textLines;

	// Use this for initialization
	void Start () {
        conversationOrder = 0;
        startConversation = 0;
        porteiroConversation = 0;

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
	}
	
	// Update is called once per frame
	void Update () {
        StartConversations();
        OrderConversations();
        StartPauseConversation();
        FinishConversation();
	}

    void StartPauseConversation()
    {
        if (Conversation)
        {
            theTextBox.SetActive(true);
            ConversationGoing();
            playerJogando = false;
        }
        else
        {
            theTextBox.SetActive(false);
            playerJogando = true;
        }
    }

    void FinishConversation()
    {
        if (finishConversation)
        {
            if(porteiroConversation == 1)
            {
                if (Player.money >=50)
                {
                    SceneManager.LoadScene("Credits");
                }
                else
                {
                    porteiroConversation = 0;
                    conversationOrder = 1;
                    Player.porteiroDoPredio = false;
                }
            }
            Conversation = false;
            finishConversation = false;
        }
    }

    void ConversationGoing()
    {
        if (Input.anyKeyDown)
        {
            if (textBox.currentLine < textBox.endAtLine)
            {
                textBox.currentLine++;
            }
            else
            {
                finishConversation = true;
            }
        }
    }

    void OrderConversations()
    {
        if(conversationOrder == 1)
        {
            if(startConversation == 0)
            {
                textBox.currentLine = 1 - 1;
                textBox.endAtLine = 3 - 1;
                Conversation = true;
                startConversation++;
            }
        }
        else if(conversationOrder == 2)
        {
            if (porteiroConversation == 0)
            {
                textBox.currentLine = 4 - 1;
                textBox.endAtLine = 7 - 1;
                Conversation = true;
                porteiroConversation++;
            }
        }
    }

    void StartConversations()
    {
        if (GameController.startconversation)
        {
            conversationOrder = 1;
        }
        if (Player.porteiroDoPredio)
        {
            conversationOrder = 2;
        }
    }
}
