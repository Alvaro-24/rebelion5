using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedaaaaaa : MonoBehaviour
{
    movimientoplayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject .CompareTag("Player"))
        {
            player.sumamoneda(1);
            Destroy(this.gameObject);
        }
    }
}
