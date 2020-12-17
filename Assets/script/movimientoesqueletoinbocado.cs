using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoesqueletoinbocado : MonoBehaviour
{
    public movimientoplayer player;
    public float speed;
    public float distanciaseseguimiento;
    SpriteRenderer giro;
    Animator controlanimaciones;
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
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((player.escudo == false) && (player.currentCDnodamage <= 0))
        {
            if (collision.gameObject.CompareTag("player"))
            {
                player.controlvida(10);
            }
        }
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
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("rayo"))
        {
            Destroy(this.gameObject);
        }
    }
   
    
}


