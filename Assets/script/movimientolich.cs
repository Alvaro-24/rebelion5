using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimientolich : MonoBehaviour
{
    public movimientoplayer player;
    public Rigidbody2D damage1;
    public float jumpforce1;
    public GameObject spaun_damage;
    public GameObject damagesufrido;
    public GameObject[] invocaiones;
    public GameObject[] spawns;
    Animator controlanimaciones;
    float CDataque = 3.5f;
    float CDinvocacion = 1.5f;
    float currentCDataque = 0;
    float currentCDinvocacion = 0;
    int vida = 900;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoplayer>();
        controlanimaciones = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCDataque <= 0)
        {
            int spawns1 = Random.Range(0, spawns.Length);
            int spawns2 = Random.Range(0, spawns.Length);
            int enemigo = Random.Range(0, invocaiones.Length);
            int enemigo2 = Random.Range(0, invocaiones.Length);
            controlanimaciones.SetTrigger("ataque1");
            Instantiate(invocaiones[enemigo], spawns[spawns1].transform.position, invocaiones[enemigo].transform.rotation);
            currentCDinvocacion = CDinvocacion;
            if (currentCDinvocacion <= 0)
            {
                controlanimaciones.SetTrigger("ataque1");
                Instantiate(invocaiones[enemigo2], spawns[spawns2].transform.position, invocaiones[enemigo2].transform.rotation);
                currentCDataque = CDataque;
            }
        }
        if (currentCDataque > 0 )
        {
            currentCDataque -= Time.deltaTime;
        }
        if (currentCDinvocacion > 0)
        {
            currentCDinvocacion -= Time.deltaTime;
        }
    }

    public void controlvida(int damage)
    {
        vida = vida - damage;
        if (vida <= 0)
        {
            Destroy(this.gameObject, 2);
            controlanimaciones.SetBool("muerto", true);
            controlanimaciones.SetTrigger("muerte");
            player.controlscore(700);
        }
    }
    
}
