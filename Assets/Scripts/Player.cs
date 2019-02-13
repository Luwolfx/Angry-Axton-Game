using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //TRAVA GERAL
    public bool PlayerJogando;
    //Movimentação do personagem:
    public float velocidade;
    private bool mover;
    private bool travamover;
    public static bool dir, esq;
    //Pulo
    public float impulso;
    public Transform sensorchao;
    public static bool EstaNoChao;
    private bool travaPular;
    private bool Pular;
    //Ataques
    public float impulsoAtaques;
    public static bool airKick;
    private bool travaAirKick;
    private bool airKickReloadTime;
    private bool isPunchActive;
    public GameObject punch;
    public static float positionhitbox;
    private bool isKickActive;
    public GameObject kick;

    //Mecanicas
    public static bool enemyatacktimer;
    public static bool enemykilled;
    public static int money;
    public static int vidas = 3;
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public GameObject vida4;
    public GameObject vida5;
    public GameObject pressA;

    private bool faseending;

    //Conversations
    public static bool porteiroDoPredio;

    //Componentes:
    private Rigidbody2D rb2d;
    private SpriteRenderer SpriteRenderer;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        vidas = 3;
        PlayerJogando = true;
        enemykilled = false;
        Pular = false;
        money = 0;
        positionhitbox = 1.3f;
        enemyatacktimer = false;
        porteiroDoPredio = false;
        faseending = false;
        airKickReloadTime = false;

        vida1.SetActive(true);
        vida2.SetActive(true);
        vida3.SetActive(true);
        vida4.SetActive(false);
        vida5.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        IsPlayerJogando();
        Vidas();

        if (faseending)
        {
            FaseEnd();
        }

        if (enemykilled)
        {
            MoneySistem();
            enemykilled = false;
        }

        //VERIFICA A POSICAO QUE O PERSONAGEM ESTÁ OLHANDO
        if(Input.GetAxis("Horizontal") < 0)
        {
            esq = true;
            dir = false;
            SpriteRenderer.flipX = true;
            punch.transform.position = new Vector2(transform.position.x - positionhitbox, punch.transform.position.y);
            kick.transform.position = new Vector2(transform.position.x - positionhitbox, kick.transform.position.y);
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            esq = false;
            dir = true;
            SpriteRenderer.flipX = false;
            punch.transform.position = new Vector2(transform.position.x + positionhitbox, punch.transform.position.y);
            kick.transform.position = new Vector2(transform.position.x + positionhitbox, kick.transform.position.y);
        }

        //VERIFICA SE ESTÁ NO CHAO
        EstaNoChao = Physics2D.Linecast(transform.position, sensorchao.position, 1 << LayerMask.NameToLayer("Chao"));
        //VERIFICA SE QUER PULAR E SE ESTA NO CHAO
        if(Input.GetAxisRaw("Vertical") == 1 && EstaNoChao)
        {
            Pular = true;
        }

        //VERIFICA SE PODE DAR UM CHUTE AEREO
        if (EstaNoChao)
        {
            airKick = false;
            travaAirKick = false;
        }
        else if(!EstaNoChao && !travaAirKick && PlayerJogando)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                airKick = true;
                travaAirKick = true;
            }
        }

        //VERIFICA SE QUER SE MECHER
		if(Input.GetAxis("Horizontal") != 0 && PlayerJogando)
        {
            mover = true;
        }
        else
        {
            mover = false;
        }

        if (!isKickActive && !EstaNoChao && !isPunchActive && PlayerJogando && !airKickReloadTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Kick(0.5f));

                isKickActive = true;
            }
        }
        if (!isPunchActive && EstaNoChao && !isKickActive && !mover && PlayerJogando)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                StartCoroutine(Punch(0.5f));

                isPunchActive = true;
            }
        }

        //Animations
        anim.SetBool("pRun", mover);
        anim.SetBool("pJump", !EstaNoChao);
        anim.SetBool("pPunch", isPunchActive);
        anim.SetBool("pKick", isKickActive);

    }

    void IsPlayerJogando()
    {
        if (Conversations.playerJogando && GameController.playerJogando)
        {
            PlayerJogando = true;
        }
        else
        {
            PlayerJogando = false;
        }

        if (PlayerJogando)
        {
            travamover = false;
            travaPular = false;
            travaAirKick = false;
        }
        else
        {
            travamover = true;
            travaPular = true;
            travaAirKick = true;
        }
    }

    void MoneySistem()
    {
        int rarity = Random.Range(1, 100);
        if (rarity <= 50)
        {
            Player.money = Player.money + Random.Range(1, 12);
        }
        if (rarity > 50 && rarity <= 85)
        {
            Player.money = Player.money + Random.Range(9, 26);
        }
        if (rarity > 85)
        {
            Player.money = Player.money + Random.Range(26, 48);
        }
    }

    void Vidas()
    {
        if(vidas == 5)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);
            vida4.SetActive(true);
            vida5.SetActive(true);
        }
        else if(vidas == 4)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);
            vida4.SetActive(true);
            vida5.SetActive(false);
        }
        else if (vidas == 3)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);
            vida4.SetActive(false);
            vida5.SetActive(false);
        }
        else if (vidas == 2)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(false);
            vida4.SetActive(false);
            vida5.SetActive(false);
        }
        else if (vidas == 1)
        {
            vida1.SetActive(true);
            vida2.SetActive(false);
            vida3.SetActive(false);
            vida4.SetActive(false);
            vida5.SetActive(false);
        }
        else if (vidas == 0)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(false);
            vida4.SetActive(false);
            vida5.SetActive(false);
            SceneManager.LoadScene("Gameover");
            Destroy(gameObject);
        }
        else if(vidas >= 6)
        {
            vidas--;
        }
    }

    void FixedUpdate()
    {
        //MOVIMENTAÇÃO DO PERSONAGEM
        if (mover && !travamover)
        {
            float run = Input.GetAxis("Horizontal") * velocidade;
            rb2d.velocity = new Vector2(run, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        //PULO DO PERSONAGEM
        if (Pular && !travaPular && PlayerJogando)
        {
            rb2d.AddForce(Vector2.up * impulso);
            Pular = false;
        }

        //CHUTE AEREO
        if (airKick && !airKickReloadTime)
        {
            if (dir)
            {
                rb2d.velocity = new Vector2(10, rb2d.velocity.y);
            }
            else if (esq)
            {
                rb2d.velocity = new Vector2(-10, rb2d.velocity.y);
            }
            travamover = true;
            StartCoroutine(airkick(0.5f));
        }
    }

    void FaseEnd()
    {
        if (Input.GetButtonDown("Fire1") && EstaNoChao && !porteiroDoPredio)
        {
            porteiroDoPredio = true;
        }
    }

    IEnumerator Punch(float punchLoad)
    {
        punch.SetActive(true);
        yield return new WaitForSeconds(punchLoad);
        punch.SetActive(false);
        isPunchActive = false;
    }

    IEnumerator Kick(float kickLoad)
    {
        kick.SetActive(true);
        yield return new WaitForSeconds(kickLoad);
        kick.SetActive(false);
        isKickActive = false;
        airKickReloadTime = true;
        StartCoroutine(AirKickReload(5f));
    }

    IEnumerator AirKickReload(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
        airKickReloadTime = false;
    }

    IEnumerator airkick(float t)
    {
        yield return new WaitForSeconds(t);
        travamover = false;
        airKick = false;
    }

    public static IEnumerator EnemyAtack(float y = 0.2f)
    {
        yield return new WaitForSeconds(y);
        enemyatacktimer = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Life")
        {
            vidas++;
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EndFase")
        {
            pressA.SetActive(true);
            faseending = true;
        }
        else
        {
            pressA.SetActive(false);
            faseending = false;
        }
    }
}
