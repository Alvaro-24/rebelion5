﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientogato : MonoBehaviour
{
    public movimientoplayer player;
    public float speed;
    public float distanciaseseguimiento;
    SpriteRenderer giro;
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

    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < distanciaseseguimiento)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if (player.transform.position.x > this.transform.position.x)
            {
                giro.flipX = false;
            }
            else if (player.transform.position.x < this.transform.position.x)
            {
                giro.flipX = true;
            }
           
            if (currentCDfuego > 0)
            {
                currentCDfuego -= Time.deltaTime;
            }
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
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
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("rayo"))
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (player.ataque1 == true)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
