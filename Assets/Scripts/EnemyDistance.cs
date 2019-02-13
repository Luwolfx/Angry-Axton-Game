using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : MonoBehaviour {

    //Manter distancia
    public bool manterdistancia;
    public Transform target;
    private float speed = 2;
    private float direction;
    public float mdistance;
    private float distance;
    private bool atacar;
    public GameObject hitbox;
    private float positionhitbox;
    private int droplife;
    public GameObject lifeHeart;
    private bool travahit;
    private bool playerAlvo;
    private bool mover;

    public bool Id01;
    public bool Id02;
    public bool Id03;
    public bool Id04;

    public static bool Id_01 = false;
    public static bool Id_02 = false;
    public static bool Id_03 = false;
    public static bool Id_04 = false;

    private GameObject a_Punch;

    //Health bar
    private bool hit;
    private int life = 100;
    public GameObject healthBarActive;
    [SerializeField] private HealthBar healthBar;

    //Components
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    private Animator anim;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        a_Punch = GameObject.Find("Audio_Punch");
        mover = false;
        playerAlvo = false;
        atacar = true;
        direction = 0;
        hitbox.SetActive(false);
        positionhitbox = 1f;
        travahit = false;

        Id_01 = false;
        Id_02 = false;
        Id_03 = false;
        Id_04 = false;
    }

    void ManterDistancia()
    {
        float moveHorizontal = direction;
        distance = Vector3.Distance(target.transform.position, transform.position);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f);
        if (mover && atacar)
        {
            rb2d.velocity = movement * speed;
        }
        else
        {
            rb2d.velocity = movement * 0;
        }

        if (target.position.x > transform.position.x)
        {
            if (distance > mdistance)
            {
                mover = true;
                direction = 1;
            }
            else
            {
                mover = false;
                if (atacar && !mover)
                {
                    if (target.position.x < transform.position.x)
                    {
                        direction = -1;
                    }
                    else
                    {
                        direction = 1;
                    }
                    if (playerAlvo)
                    {
                        StartCoroutine(Atack());
                        StartCoroutine(HitboxAppear());
                        atacar = false;
                    }
                }
            }
        }
        else if (target.position.x < transform.position.x)
        {
            if (distance > mdistance)
            {
                mover = true;
                direction = -1;
            }
            else
            {
                mover = false;
                if(target.position.x < transform.position.x)
                {
                    direction = -1;
                }
                else
                {
                    direction = 1;
                }
                if (atacar && !mover)
                {
                    if (playerAlvo)
                    {
                        StartCoroutine(Atack());
                        StartCoroutine(HitboxAppear());
                        atacar = false;
                    }
                }
            }
        }
    }

    void OlhandoPara()
    {
        if(direction == 1)
        {
            sprite.flipX = false;
            hitbox.transform.position = new Vector2(transform.position.x + positionhitbox, hitbox.transform.position.y);
        }
        else if(direction == -1)
        {
            sprite.flipX = true;
            hitbox.transform.position = new Vector2(transform.position.x - positionhitbox, hitbox.transform.position.y);
        }
    }

    void PlayerAlvo()
    {
        if (Id01)
        {
            if (Id_01)
            {
                playerAlvo = true;
            }
        }
        if (Id02)
        {
            if (Id_02)
            {
                playerAlvo = true;
            }
        }
        if (Id03)
        {
            if (Id_03)
            {
                playerAlvo = true;
            }
        }
        if (Id04)
        {
            if (Id_04)
            {
                playerAlvo = true;
            }
        }

        if (playerAlvo)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            mdistance = 2f;
        }
    }
	
	// Update is called once per frame
	void Update () {

        OlhandoPara();
        PlayerAlvo();

        if (manterdistancia)
        {
            ManterDistancia();
        }
        
        //Healthbar Show
        if (life == 100)
        {
            for (int i = 0; i < 1; i++)
            {
                healthBar.SetSize(1f);
                healthBarActive.SetActive(false);
            }
        }
        else if (life == 90)
        {
            for (int i = 0; i < 1; i++)
            {
                healthBar.SetSize(.9f);
                healthBarActive.SetActive(true);
            }
        }
        else if (life == 80)
        {
            for (int i = 0; i < 1; i++)
            {
                healthBar.SetSize(.8f);
                healthBarActive.SetActive(true);
            }
        }
        else if (life == 70)
        {
            for (int i = 0; i < 1; i++)
            {
                healthBar.SetSize(.7f);
                healthBarActive.SetActive(true);
            }
        }
        else if (life == 60)
        {
            for (int i = 0; i < 1; i++)
            {
                healthBar.SetSize(.6f);
                healthBarActive.SetActive(true);
            }
        }
        else if (life == 50)
        {
            for (int i = 0; i < 1; i++)
            {
                healthBar.SetSize(.5f);
                healthBarActive.SetActive(true);
            }
        }
        else if (life == 40)
        {
            for (int i = 0; i < 1; i++)
            {
                healthBar.SetSize(.4f);
                healthBarActive.SetActive(true);
            }
        }
        else if (life == 30)
        {
            for (int i = 0; i < 1; i++)
            {
                healthBar.SetSize(.3f);
                healthBarActive.SetActive(true);
            }
        }
        else if (life == 20)
        {
            for (int i = 0; i < 1; i++)
            {
                healthBar.SetSize(.2f);
                healthBarActive.SetActive(true);
            }
        }
        else if (life == 10)
        {
            for (int i = 0; i < 1; i++)
            {
                healthBar.SetSize(.1f);
                healthBarActive.SetActive(true);
            }
        }
        else if (life <= 0)
        {
            for (int i = 0; i < 1; i++)
            {
                healthBar.SetSize(0f);
                healthBarActive.SetActive(true);
                Player.enemykilled = true;
                droplife = Random.Range(1, 100);
                if (droplife <= 10)
                {
                    Instantiate(lifeHeart, transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }
        }

        if (hit)
        {
            mover = false;
            StartCoroutine(Hit(0.2f));
            a_Punch.GetComponent<AudioSource>().Play();
        }

        //Animations
        anim.SetBool("caWalk", mover);
        anim.SetBool("caAttack", !atacar);
    }

    public IEnumerator Hit(float h)
    {
        yield return new WaitForSeconds(h);
        hit = false;
    }

    IEnumerator TravarHit(float p = 0.5f)
    {
        yield return new WaitForSeconds(p);
        travahit = false;
    }

    IEnumerator Atack(float t = 2)
    {
        yield return new WaitForSeconds(t);
    }

    IEnumerator HitboxAppear(float y = 1)
    {
        yield return new WaitForSeconds(y);
        hitbox.SetActive(true);
        StartCoroutine(HitboxDisappear());
    }

    IEnumerator HitboxDisappear(float u = 0.2f)
    {
        yield return new WaitForSeconds(u);
        hitbox.SetActive(false);
        atacar = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Punch")
        {
            if (!hit && !travahit)
            {
                life = life - 10;
                playerAlvo = true;
                mdistance = 2f;
                StartCoroutine(TravarHit());
                travahit = true;
                hit = true;
            }
        }
        if (col.gameObject.tag == "Kick")
        {
            if (Player.airKick)
            {
                for (int i = 0; i < 1; i++)
                {
                    if (!hit && !travahit)
                    {
                        life = life - 20;
                        playerAlvo = true;
                        mdistance = 2f;
                        StartCoroutine(TravarHit());
                        travahit = true;
                        hit = true;
                    }
                }
            }
        }
    }
}
