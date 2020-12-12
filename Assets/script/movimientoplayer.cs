using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoplayer : MonoBehaviour
{
    public float speed;
    Camera camarapueblo;
    public float maxXpueblo, maxYpueblo, minXpueblo, minYpueblo;
    public Camera camarajugador1;
    public float jumpforce;
    public Rigidbody2D salto;
    public float cameradistance;
    bool paredderecha = false;
    bool paredizquierda = false;
    public float vida;
    float intentos = 5;
    public float score;
    int monedas;
    int nivel = 0;
    int pocion = 25;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.5f)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") < -0.5f)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            salto.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            if (paredderecha == true)
            {
                salto.AddForce(new Vector2(-0.5f, jumpforce), ForceMode2D.Impulse);
            }
            if (paredizquierda == true)
            {
                salto.AddForce(new Vector2(0.5f, jumpforce), ForceMode2D.Impulse);
            }
        }
        camarapueblo.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXpueblo, maxXpueblo), Mathf.Clamp(this.transform.position.y, minYpueblo, maxYpueblo), this.transform.rotation.z - cameradistance);
        if (monedas == 100)
        {
            controlintentosmas(1);
            monedas = 0;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha1)) && (nivel >= 3) && (nivel <= 5))
        {

        }
        if ((Input.GetKeyDown(KeyCode.Alpha2)) && (nivel >= 5) && (nivel <= 10))
        {

        }
        if ((Input.GetKeyDown(KeyCode.Alpha3)) && (nivel >= 10) && (nivel <= 15))
        {

        }
        if ((Input.GetKeyDown(KeyCode.Alpha4)) && (nivel >= 15) && (nivel <= 20))
        {

        }
        if (nivel >= 20)
        {
            vida = 300;
        }
        else if (nivel >= 15)
        {
            vida = 250;
        }
        else if (nivel >= 10)
        {
            vida = 200;
        }
        else if (nivel >= 5)
        {
            nivel = 150;
        }
    }
    private void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pared"))
        {
            if (this.transform.position.x > collision.transform.position.x)
            {
                paredizquierda = true;
            }
            if (this.transform.position.x < collision.transform.position.x)
            {
                paredderecha = true;
            }
        }
        if (collision.gameObject.CompareTag("vida"))
        {
            sumarvida(pocion);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("moneda"))
        {
            sumamoneda(1);
            Destroy(collision.gameObject);
        }

    }
    public void controlintentosmas(int masintentos)
    {
        intentos = intentos + masintentos;
    }
    public void controlvida(int damage)
    {
        vida = vida - damage;
    }
    public void controldintentosmenos(int menosintentos)
    {
        intentos = intentos - menosintentos;
    }
    public void sumarvida(int vidarecogida)
    {
        vida = vida + vidarecogida;
    }
    public void controlscore(int scoremas)
    {
        score = score + scoremas;
    }
    public void sumamoneda(int monedarecojida)
    {
        monedas = monedas + monedarecojida;
    }
    public void cintrolniveles(int nivelmas)
    {
        nivel = nivel + nivelmas;
    }
}
