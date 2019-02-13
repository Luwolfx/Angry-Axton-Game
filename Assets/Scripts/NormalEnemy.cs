using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour {

    private float vel = 2;
    private bool mover;
    private int vaiandar;
    private int vaivoltar;
    private bool hit;
    private int life = 100;
    private int droplife;
    public GameObject lifeHeart;
    private bool travahit;

    //Manter distancia
    private bool manterdistancia;
    private Transform target;
    private float speed = 2;
    private float direction;
    public float mdistance;
    private float distance;

    //Capangas ativo
    public bool Id01;
    public bool Id02;
    public bool Id03;
    public bool Id04;

    private GameObject a_Punch;
    public GameObject healthBarActive;
    [SerializeField] private HealthBar healthBar;

    //Componentes
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    private Animator anim;


    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        a_Punch = GameObject.Find("Audio_Punch");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mover = true;
        StartCoroutine(andar(3));
        StartCoroutine(trocarrota(5));
        healthBar.SetSize(1f);
        hit = false;
        manterdistancia = false;
    }


    void ManterDistancia()
    {
        float moveHorizontal = direction;
        distance = Vector3.Distance(target.transform.position, transform.position);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f);
        if (mover)
        {
            rb2d.velocity = movement * speed;
        }
        else
        {
            rb2d.velocity = movement * 0;
        }

        if (target.position.x < transform.position.x)
        {
            sprite.flipX = false;
            if (distance < mdistance)
            {
                mover = true;
                direction = 1;
            }
            else
            {
                mover = false;
            }
        }
        else if (target.position.x > transform.position.x)
        {
            if (distance < mdistance)
            {
                sprite.flipX = true;
                mover = true;
                direction = -1;
            }
            else
            {
                mover = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {

        if (manterdistancia)
        {
            ManterDistancia();
        }

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
                if(droplife <= 15)
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
            manterdistancia = true;
        }

        //Animations
        anim.SetBool("neWalk", mover);

    }

    private void FixedUpdate()
    {
        if (!manterdistancia)
        {
            if (mover)
            {
                float run = 1 * vel;
                rb2d.velocity = new Vector2(run, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
        }
    }

    IEnumerator andar(float t)
    {
        if (!manterdistancia)
        {
            yield return new WaitForSeconds(t);
            vaiandar = Random.Range(1, 5);
            if (vaiandar > 1)
            {
                mover = true;
                StartCoroutine(andar(4));
            }
            else
            {
                mover = false;
                StartCoroutine(andar(2));
            }
        }
    }

    IEnumerator trocarrota(float y)
    {
        if (!manterdistancia)
        {
            yield return new WaitForSeconds(y);
            vaivoltar = Random.Range(1, 3);
            if (vaivoltar == 1)
            {
                vel = vel * -1;
                sprite.flipX = !sprite.flipX;
                StartCoroutine(trocarrota(8));
            }
            else
            {
                StartCoroutine(trocarrota(5));
            }
        }
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Limite")
        {
            vel = vel * -1;
            sprite.flipX = !sprite.flipX;
        }

        if (col.gameObject.tag == "Punch")
        {
            if (!hit && !travahit)
            {
                life = life - 20;
                hit = true;
                StartCoroutine(TravarHit());
                travahit = true;
                if (Id01)
                {
                    EnemyDistance.Id_01 = true;
                }
                else if (Id02)
                {
                    EnemyDistance.Id_02 = true;
                }
                else if (Id03)
                {
                    EnemyDistance.Id_03 = true;
                }
                else if (Id04)
                {
                    EnemyDistance.Id_04 = true;
                }
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
                        life = life - 40;
                        hit = true;
                        StartCoroutine(TravarHit());
                        travahit = true;
                        if (Id01)
                        {
                            EnemyDistance.Id_01 = true;
                        }
                        else if (Id02)
                        {
                            EnemyDistance.Id_02 = true;
                        }
                        else if (Id03)
                        {
                            EnemyDistance.Id_03 = true;
                        }
                        else if (Id04)
                        {
                            EnemyDistance.Id_04 = true;
                        }
                    }
                }
            }
        }
    }
}
