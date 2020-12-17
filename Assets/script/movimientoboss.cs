using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoboss : MonoBehaviour
{
    public float speed;
    public movimientoplayer player;
    public float distanciaseseguimiento;
    public float distanciaplayer;
    SpriteRenderer giro;
    bool ataque1 = false;
    bool ataque2 = false;
    public float CDataque1;
    public float CDataque2;
  
    float currentCDataque1;
    float currentCDataque2;
  
    public GameObject cortefuego;
    public GameObject spawncorte;
    public GameObject[] bosses;
    public GameObject spawnbosses;
    Animator controlanimaciones;
    int vida = 2500;
    public float CDnodamage;
    float currentCDnodamage = 0;
    public GameObject sitioespera;
    public GameObject posicionbatalla;
    public GameObject[] posicionbatalla2;
    bool enemigo1 = false;
    bool enemigo2 = false;
    bool enemigo3 = false;
    GameObject enemigo1_0;
    GameObject enemigo2_0;
    GameObject enemigo3_0;

    public GameObject muertefuego;
    public GameObject spawnfuego;
    float CDfuego = 0.75f;
    float currentCDfuego = 0;

    float CDposicionbatalla = 10;
    float currentCDposicionbatalla;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoplayer>();
        giro = this.GetComponent<SpriteRenderer>();
        int posicion = Random.Range(0, posicionbatalla2.Length);
        this.transform.position = posicionbatalla2[posicion].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (distanciaplayer < 2)
        {
            ataque1 = true;
            controlanimaciones.SetTrigger("ataque1");
            currentCDataque1 = CDataque1;
        }
        else if (distanciaplayer > 2)
        {
            ataque2 = true;
            controlanimaciones.SetTrigger("ataque1");
            Instantiate(cortefuego, spawncorte.transform.position, cortefuego.transform.rotation);
            currentCDataque2 = CDataque2;
        }
        if (vida <= 625)
        {
            if (enemigo1 == false)
            {
                controlanimaciones.SetTrigger("ataque2");
                enemigo1_0 = Instantiate(bosses[1], spawnbosses.transform.position, bosses[0].transform.rotation);
                enemigo1 = true; 
            }
           
            if (enemigo1_0 == null)
            {
                if (currentCDposicionbatalla <= 0)
                {
                    controlmago();
                }
            }
            else 
            {

                this.transform.position = Vector3.MoveTowards(this.transform.position, sitioespera.transform.position, speed * Time.deltaTime);
            }

        }
        else if (vida <= 1225)
        {
            if (enemigo2 == false)
            {
                controlanimaciones.SetTrigger("ataque2");
                enemigo2_0 = Instantiate(bosses[2], spawnbosses.transform.position, bosses[1].transform.rotation);
                enemigo2 = true;
            }
            if (enemigo2_0 == null)
            {
                if (currentCDposicionbatalla <= 0)
                {
                    controlmago();
                }
            }
            else
            {

                this.transform.position = Vector3.MoveTowards(this.transform.position, sitioespera.transform.position, speed * Time.deltaTime);
            }
        }
        else if (vida <= 1875)
        {
            if (enemigo3 == false)
            {
                controlanimaciones.SetTrigger("ataque2");
                enemigo3_0 = Instantiate(bosses[3], spawnbosses.transform.position, bosses[2].transform.rotation);
                enemigo3 = true;
            }
            if (enemigo3_0 == null)
            {
                if (currentCDposicionbatalla <= 0)
                {
                    controlmago();
                }
            }
            else
            {

                this.transform.position = Vector3.MoveTowards(this.transform.position, sitioespera.transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            controlmago();
        }
        if (currentCDnodamage > 0)
        {
            currentCDnodamage -= Time.deltaTime;
        }
        if (currentCDataque1 > 0)
        {
            currentCDataque1 -= Time.deltaTime;
        } 
        if (currentCDataque2 > 0)
        {
            currentCDataque2 -= Time.deltaTime;
        } 
        if (currentCDposicionbatalla > 0)
        {
            currentCDposicionbatalla -= Time.deltaTime;
        }
        if (player.transform.position.x > this.transform.position.x)
        {
            giro.flipX = false;
        }
        else if (player.transform.position.x < this.transform.position.x)
        {
            giro.flipX = true;
        }
    }
    public void controlmago()
    {
        int posicion = Random.Range(0, posicionbatalla2.Length);
        this.transform.position = Vector3.MoveTowards(this.transform.position, posicionbatalla2[posicion].transform.position, speed * Time.deltaTime);
        currentCDposicionbatalla = CDposicionbatalla;
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
            player.controlvida(4000);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentCDnodamage <= 0)
        {
            if (collision.gameObject.CompareTag("player"))
            {
                if (player.ataque1 == true)
                {
                    controlvida(player.espadazo);
                }
            }
            if (collision.gameObject.CompareTag("boladefuego"))
            {
                controlvida(player.fuego);
                Destroy(collision.gameObject);
                GameObject muerte = Instantiate(muertefuego, spawnfuego.transform.position, muertefuego.transform.rotation);
                currentCDfuego = CDfuego;
                if (currentCDfuego <= 0)
                {
                    Destroy(muerte);
                }
            }
            if (collision.gameObject.CompareTag("rayo"))
            {
                controlvida(player.relanpago);
            }
            if (collision.gameObject.CompareTag("corte"))
            {
                controlvida(player.tajo);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("player"))
        {
            if ((player.escudo == false) && (player.currentCDnodamage <= 0))
            {
                if (ataque1 == true)
                {
                    player.controlvida(35);
                }
                if (ataque2 == true)
                {
                    player.controlvida(20);
                }
            }
        }
        
    }
}
