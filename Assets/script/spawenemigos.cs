using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawenemigos : MonoBehaviour
{
    public movimientoplayer player;
    public movimientoplayerrey rey;

    public GameObject spawn;
    public GameObject enemigo;
    GameObject enemigo1;
    int enemigos = 5;
    float distanciaplayer1 = 30;
    float distanciaplayer2 = 50;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoplayer>();
        rey = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoplayerrey>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((enemigo1 == null) && (enemigos > 0))
        {
            if ((Vector3.Distance(this.transform.position, player.transform.position) < distanciaplayer1) && (Vector3.Distance(this.transform.position, player.transform.position) < distanciaplayer2))
            {
                enemigo1 = Instantiate(enemigo, spawn.transform.position, enemigo.transform.rotation);
                controlenemigos(1);
                
            }
        }
       
    }
    public void controlenemigos(int enemigospawneado)
    {
        enemigos = enemigos - enemigospawneado;
    }
}
