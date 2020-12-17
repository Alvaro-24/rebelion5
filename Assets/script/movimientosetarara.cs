using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientosetarara : MonoBehaviour
{
    public movimientoplayer player;
    public float speed;
    public float distanciaseseguimiento;
    public float distanciaplayer;
    SpriteRenderer giro;
    bool ataque1 = false;
    public float CDataque1;
    float currentCDataque1 = 0;
    bool ataque2 = false;
    public float CDatque2;
    float currentCdataque2;
    Animator controlanimaciones;
    int vida = 3;
    public float CDnodamage;
    float currentCDnodamage = 0;
    public GameObject muertefuego;
    public GameObject spawnfuego;
    float CDfuego = 0.75f;
    float currentCDfuego = 0;
    public Rigidbody2D salto;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoplayer>();
        giro = this.GetComponent<SpriteRenderer>();
        controlanimaciones = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(this.transform.position, player.transform.position) < distanciaseseguimiento)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            controlanimaciones.SetBool("correr", true);
            if (player.transform.position.x > this.transform.position.x)
            {
                giro.flipX = false;
            }
            else if (player.transform.position.x < this.transform.position.x)
            {
                giro.flipX = true;
            }
            else
            {
                controlanimaciones.SetBool("correr", false);
            }
            if (distanciaplayer <= 2)
            {
                controlanimaciones.SetTrigger("ataque1");
                ataque1 = true;
                currentCDataque1 = CDataque1;
            }
            else
            {
                ataque1 = false;
            }
            if (distanciaplayer <= 4)
            {
                controlanimaciones.SetTrigger("ataque2");
                ataque2 = true;
                currentCdataque2 = CDatque2;
            }
            else
            {
                ataque2 = false;
            }

        }
        if (currentCDnodamage > 0)
        {
            currentCDnodamage -= Time.deltaTime;
        }
        if (currentCDnodamage <= 0)
        {
            currentCDnodamage = CDnodamage;
        }
        if (currentCDfuego > 0)
        {
            currentCDfuego -= Time.deltaTime;
        }
        if (salto.velocity.y < -0.2f)
        {
            controlanimaciones.SetBool("caida", true);
        }
        else
        {
            controlanimaciones.SetBool("caida", false);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((player.escudo == false) && (player.currentCDnodamage <= 0))
        {
            if (collision.gameObject.CompareTag("player"))
            {
                if (ataque1 == true)
                {
                    player.controlvida(15);
                }
                if (ataque2 == true)
                {
                    player.controlscore(15);
                }
            }
        }
        if (currentCDnodamage <= 0)
        {
            if (collision.gameObject.CompareTag("boladefuego"))
            {
                Destroy(collision.gameObject);
                GameObject muerte = Instantiate(muertefuego, spawnfuego.transform.position, muertefuego.transform.rotation);
                currentCDfuego = CDfuego;
                if (currentCDfuego <= 0)
                {
                    Destroy(muerte);
                    Destroy(this.gameObject);
                }

            }
            if (collision.gameObject.CompareTag("corte"))
            {
                Destroy(collision.gameObject);
                controlvida(1);
            }
            if (collision.gameObject.CompareTag("rayo"))
            {
                controlvida(2);
            }
        }
        
       
    }
    public void controlvida(int damage)
    {
        if (vida > 0)
        {
            vida = vida - damage;
            CDnodamage = currentCDnodamage;
            controlanimaciones.SetTrigger("recibir_golpe");
        }
        if (vida <= 0)
        {
            Destroy(this.gameObject, 2);
            controlanimaciones.SetBool("muerto", true);
            controlanimaciones.SetTrigger("muerte");
            player.controlscore(50);
        }
    }
}
