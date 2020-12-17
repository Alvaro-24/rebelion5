using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class movimientoplayer : MonoBehaviour
{
    public float speed;
    Vector2 mousePosition;
    //camaras
    Camera camaraactual;
    GameObject espaumactual;
    public Camera camarapueblo1;
    public GameObject respawn1;
    public Camera camarapueblo2;
    public GameObject respawn2;
    public Camera camaracamino;
    public GameObject respawn3;
    public Camera camaraclaro;
    public GameObject respawn4;
    public Camera camarabosqueverde;
    public GameObject respawn5;
    public Camera camarabosqueniebla;
    public GameObject respawn6;
    public Camera camarabosqueoscuro;
    public GameObject respawn7;
    public Camera camaracementerio;
    public GameObject respawn8;
    public Camera camaracripta;
    public GameObject respawn9;
    public Camera camaracueva;
    public GameObject respawn10;
    public Camera camaraacantilado;
    public GameObject respawn11;
    public Camera camaracaminomontaña;
    public GameObject respawn12;
    public Camera camaracastillofondo;
    public GameObject respawn13;
    public Camera camaracastillo;
    public GameObject respawn14;
    public Camera camaraboss;
    public GameObject respawn15;
    public float maxXpueblo1, maxYpueblo1, minXpueblo1, minYpueblo1;
    public float Xpueblo1, Ypueblo1;
    public float maxXpueblo2, maxYpueblo2, minXpueblo2, minYpueblo2;
    public float Xpueblo2, Ypueblo2;
    public float maxXcamino, minXcamino, maxYcamino, minYcamino;
    public float Xcamino, Ycamino;
    public float maxXClaro, minXclaro, maxYclaro, minYclaro;
    public float Xclaro, Yclaro;
    public float maxXbosqueverde, minXbosqueverde, maxYbosqueverde, minYbosqueverde;
    public float Xbosqueverde, Ybosqueverde;
    public float maxXbosqueniebla, minXbosniebla, maxYbosniebla, minYbosqueniebla;
    public float Xbosqueniebla, Ybosqueniebla;
    public float maxXbosqueoscuro, minXbosqueoscuro, maxYbososcuro, minYbosqueoscuro;
    public float Xbosqueoscuro, Ybosqueoscuro;
    public float maxXcementerio, minXcementerio, maxYcementerio, minYcementerio;
    public float Xcementerio, Ycementerio;
    public float maxXcripta, minXcripta, maxYcripta, minYcripta;
    public float Xcripta, Ycripta;
    public float maxXcueva, minXcueva, maxYcueva, minYcueva;
    public float Xcueva, Ycueva;
    public float maxXacantilado, minXacantilado, maxYacantilado, minYacantilado;
    public float Xacantilado, Yacantilado;
    public float maxXcaminomontaña, minXcaminomontaña, maxYcaminomontaña, minYcaminomontaña;
    public float Xcaminomontaña, Ycaminomontaña;
    public float maxXcastillofondo, minXcastillofondo, maxYcastillofondo, minYcastillofondo;
    public float Xcastillofondo, Ycastillofondo;
    public float maxXcastillo, minXcastillo, maxYcastillo, minYcastillo;
    public float Xcastillo, Ycastillo;
    public float maxXboss, minXboss, maxYboss, minYboss;
    public float Xboss, Yboss;
    bool posicionpueblo1 = false;
    bool posicionpueblo2 = false;
    bool posicioncamino = false;
    bool posicionclaro = false;
    bool posicionbosqueverde = false;
    bool posicionbosniebla = false;
    bool posicionbososcuro = false;
    bool posicioncementerio = false;
    bool posicioncripta = false;
    bool posicioncueva = false;
    bool posicionacantilado = false;
    bool posicioncaminomontaña = false;
    bool posicioncastillofondo = false;
    bool posicioncastillo = false;
    bool posicionboss = false;

    //animaciones
    Animator controlanimaciones;
    [Header("Bools")]
    #region bools
    public bool escudo = false;
    public bool ataque1 = false;
    public bool ataque2 = false;
    public bool ataque3 = false;
    public bool ataque4 = false;
    bool ataque5 = false;
    #endregion
    public float CDataque1;
    public float CDataque2;
    public float CDataque3;
    public float CDataque4;
     float currentCDataque1;
     float currentCDataque2;
     float currentCDataque3;
     float currentCDataque4;
    public float CDescudo;
     float currentCDescudo;
    public float CDnodamage;
    public float currentCDnodamage;
    public GameObject escudos;
    public GameObject spawnescudo;

    public GameObject boladefuego;
    public GameObject spawnboladefuego;

    public GameObject atquecircular;
    public GameObject spawnatquecircular;

    public GameObject rayo;

    public float CDrevivir;
    public float currentCDrevivir;

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
    public int espadazo;
    public int tajo;
    public int fuego;
    public int relanpago;
    GameObject daño;
 

    // Start is called before the first frame update
    void Start()
    {
        controlanimaciones = GetComponent<Animator>();
        


    }

    // Update is called once per frame
    void Update()
    {
        if (posicionpueblo1 == true)
        {
            movimiento();
            camarapueblo1.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXpueblo1, maxXpueblo1), Mathf.Clamp(this.transform.position.y, minYpueblo1, maxYpueblo1), this.transform.rotation.z - cameradistance);
            camaraactual = camarapueblo1;
            espaumactual = respawn1;
        }
        if (posicionpueblo2 == true)
        {
            movimiento();
            camarapueblo2.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXpueblo2, maxXpueblo2), Mathf.Clamp(this.transform.position.y, minYpueblo2, maxYpueblo2), this.transform.rotation.z - cameradistance);
            camaraactual = camarapueblo2;
            espaumactual = respawn2;
        }
        if (posicioncamino == true)
        {
            movimiento();
            camaracamino.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXcamino, maxXcamino), Mathf.Clamp(this.transform.position.y, minYcamino, maxYcamino), this.transform.rotation.z - cameradistance);
            camaraactual = camaracamino;
            espaumactual = respawn3;
        }
        if (posicionclaro == true)
        {
            movimiento();
            camaraclaro.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXclaro, maxXClaro), Mathf.Clamp(this.transform.position.y, minYclaro, maxYclaro), this.transform.rotation.z - cameradistance);
            camaraactual = camaraclaro;
            espaumactual = respawn4;
        }
        if (posicionbosqueverde == true)
        {
            movimiento();
            camarabosqueverde.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXbosqueverde, maxXbosqueverde), Mathf.Clamp(this.transform.position.y, minYbosqueverde, maxYbosqueverde), this.transform.rotation.z - cameradistance);
            camaraactual = camarabosqueverde;
            espaumactual = respawn5;
        }
        if (posicionbosniebla == true)
        {
            movimiento();
            camarabosqueniebla.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXbosniebla, maxXbosqueniebla), Mathf.Clamp(this.transform.position.y, minYbosqueniebla, maxYbosniebla), this.transform.rotation.z - cameradistance);
            camaraactual = camarabosqueniebla;
            espaumactual = respawn6;
        }
        if (posicionbososcuro == true)
        {
            movimiento();
            camarabosqueoscuro.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXbosqueoscuro, maxXbosqueoscuro), Mathf.Clamp(this.transform.position.y, minYbosqueoscuro, maxYbososcuro), this.transform.rotation.z - cameradistance);
            camaraactual = camarabosqueoscuro;
            espaumactual = respawn7;
        }
        if (posicioncementerio == true)
        {
            movimiento();
            camaracementerio.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXcementerio, maxXcementerio), Mathf.Clamp(this.transform.position.y, minYcementerio, maxYcementerio), this.transform.rotation.z - cameradistance);
            camaraactual = camaracementerio;
            espaumactual = respawn8;
        }
        if (posicioncripta == true)
        {
            movimiento();
            camaracripta.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXcripta, maxXcripta), Mathf.Clamp(this.transform.position.y, minYcripta, maxYcripta), this.transform.rotation.z - cameradistance);
            camaraactual = camaracripta;
            espaumactual = respawn9;
        }
        if (posicioncueva == true)
        {
            movimiento();
            camaracueva.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXcueva, maxXcueva), Mathf.Clamp(this.transform.position.y, minYcueva, maxYcueva), this.transform.rotation.z - cameradistance);
            camaraactual = camaracueva;
            espaumactual = respawn10;
        }
        if (posicionacantilado == true)
        {
            movimiento();
            camaraacantilado.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXacantilado, maxXacantilado), Mathf.Clamp(this.transform.position.y, minYacantilado, maxYacantilado), this.transform.rotation.z - cameradistance);
            camaraactual = camaraacantilado;
            espaumactual = respawn11;
        }
        if (posicioncaminomontaña == true)
        {
            movimiento();
            camaracaminomontaña.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXcaminomontaña, maxXcaminomontaña), Mathf.Clamp(this.transform.position.y, minYcaminomontaña, maxYcaminomontaña), this.transform.rotation.z - cameradistance);
            camaraactual = camaracaminomontaña;
            espaumactual = respawn12;
        }
        if (posicioncastillofondo == true)
        {
            movimiento();
            camaracastillofondo.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXcastillofondo, maxXcastillofondo), Mathf.Clamp(this.transform.position.y, minYcastillofondo, maxYcastillofondo), this.transform.rotation.z - cameradistance);
            camaraactual = camaracastillofondo;
            espaumactual = respawn13;
        }
        if (posicioncastillo == true)
        {
            movimiento();
            camaracastillo.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXcastillo, maxXcastillo), Mathf.Clamp(this.transform.position.y, minYcastillo, maxYcastillo), this.transform.rotation.z - cameradistance);
            camaraactual = camaracastillo;
            espaumactual = respawn14;
        }
        if (posicionboss == true)
        {
            movimiento();
            camaraboss.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minXboss, maxXboss), Mathf.Clamp(this.transform.position.y, minYboss, maxYboss), this.transform.rotation.z - cameradistance);
            camaraactual = camaraboss;
            espaumactual = respawn15;
        }
        if (monedas == 100)
        {
            controlintentosmas(1);
            monedas = 0;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha2)) && (nivel >= 3))
        {
            escudo = true;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha2)) && (nivel >= 3) && (nivel <= 5))
        {
            ataque2 = true;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha3)) && (nivel >= 5) && (nivel <= 10))
        {
            ataque3 = true;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha4)) && (nivel >= 10) && (nivel <= 15))
        {
            ataque4 = true;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha5)) && (nivel >= 15) && (nivel <= 20))
        {
            ataque5 = true;
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
        if (currentCDescudo > 0)
        {
            currentCDescudo -= Time.deltaTime;
            if (currentCDescudo <= 0)
            {
                currentCDescudo = CDescudo;
            }
        }
        if (currentCDataque1 > 0)
        {
            currentCDataque1 -= Time.deltaTime;
            if (currentCDataque1 <= 0)
            {
                currentCDataque1 = CDataque1;
            }
        }

        if (currentCDataque2 > 0)
        {
            currentCDataque2 -= Time.deltaTime;
            if (currentCDataque2 <= 0)
            {
                currentCDataque2 = CDataque2;
            }
        }
        if (currentCDataque3 > 0)
        {
            currentCDataque3 -= Time.deltaTime;
            if (currentCDataque3 <= 0)
            {
                currentCDataque3 = CDataque3;
            }
        }
        if (currentCDataque4 > 0)
        {
            currentCDescudo -= Time.deltaTime;
            if (currentCDataque4 <= 0)
            {
                currentCDataque4 = CDataque4;
            }
        }
        if (currentCDrevivir > 0)
        {
            currentCDrevivir -= Time.deltaTime;
        }
        if (currentCDnodamage > 0)
        {
            currentCDnodamage -= Time.deltaTime;
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
        if ((escudo == false) && (currentCDnodamage <= 0))
        {
            if (collision.gameObject.CompareTag("pincho"))
            {
                controlvida(2);

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
        if (collision.gameObject.CompareTag("cortefuego")) 
        {
            if ((escudo == false) && (currentCDnodamage <= 0))
            {
                controlvida(18);
                Destroy(collision.gameObject);
            }
        }
       
        
    }
    public void controlintentosmas(int masintentos)
    {
        intentos = intentos + masintentos;
        if (intentos <= 0)
        {
            controlanimaciones.SetTrigger("muerte");
        }
    }
    public void controlvida(int damage)
    {
        vida = vida - damage;
        CDnodamage = currentCDnodamage;
        controlanimaciones.SetTrigger("recibir_golpe");
        if (vida <= 0)
        {
            controlanimaciones.SetTrigger("muerte");
            controlanimaciones.SetBool("muerto", true);
            CDrevivir = currentCDrevivir;
            if (currentCDrevivir <= 0)
            {
                this.transform.position = espaumactual.transform.position;
            }
           
        }
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
    // control de camaras
    public void camaracontrolerpueblo1()
    {
        posicionpueblo1 = true;
        camarapueblo1.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xpueblo1, Ypueblo2);
    }
    public void camaracontrolerpueblo2()
    {
        posicionpueblo1 = false;
        camarapueblo1.gameObject.SetActive(false);
        camarapueblo2.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xpueblo2, Ypueblo2);
    }
    public void camaracontrolercamino()
    {
        posicionpueblo2 = false;
        camarapueblo2.gameObject.SetActive(false);
        camaracamino.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xcamino, Ycamino);
    }
    public void camaracontrolerclaro()
    {
        posicioncamino = false;
        camaracamino.gameObject.SetActive(false);
        camaraclaro.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xclaro, Yclaro);
    }
    public void camaracontrolerbosqueverde()
    {
        posicionclaro = false;
        camaraclaro.gameObject.SetActive(false);
        camarabosqueverde.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xbosqueverde, Ybosqueverde);
    }
    public void camaracontrolerbosqueniebla()
    {
        posicionbosqueverde = false;
        camarabosqueverde.gameObject.SetActive(false);
        camarabosqueniebla.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xbosqueniebla, Ybosqueniebla);
    }
    public void camaracontrolerbosqueoscuro()
    {
        posicionbosniebla = false;
        camarabosqueniebla.gameObject.SetActive(false);
        camarabosqueoscuro.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xbosqueoscuro, Ybosqueoscuro);
    }
    public void camaracontrolercemeinterio()
    {
        posicionbososcuro = false;
        camarabosqueoscuro.gameObject.SetActive(false);
        camaracementerio.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xcementerio, Ycementerio);
    }
    public void camaracontrolercripta()
    {
        posicioncementerio = false;
        camaracementerio.gameObject.SetActive(false);
        camaracripta.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xcripta, Ycripta);
    }
    public void camaracontrolercueva()
    {
        posicioncripta = false;
        camaracripta.gameObject.SetActive(false);
        camaracueva.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xcueva, Ycueva);
    }
    public void camaracontroleracantilado()
    {
        posicioncueva = false;
        camaracueva.gameObject.SetActive(false);
        camaraacantilado.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xacantilado, Yacantilado);
    }
    public void camaracontrolercaminomontaña()
    {
        posicionacantilado = false;
        camaraacantilado.gameObject.SetActive(false);
        camaracaminomontaña.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xcaminomontaña, Ycaminomontaña);
    }
    public void camaracontrolercastillofondo()
    {
        posicioncaminomontaña = false;
        camaracaminomontaña.gameObject.SetActive(false);
        camaracastillofondo.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xcastillofondo, Ycastillofondo);
    }
    public void camaracontrolercastillo()
    {
        posicioncastillofondo = false;
        camaracastillofondo.gameObject.SetActive(false);
        camaracastillo.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xcastillo, Ycastillo);
    }
    public void camaracontrolerboss()
    {
        posicioncastillo = false;
        camaracastillo.gameObject.SetActive(false);
        camaraboss.gameObject.SetActive(true);
        this.transform.position = new Vector2(Xboss, Yboss);
    }
    public void movimiento()
    {
        if (Input.GetAxis("Horizontal") > 0.5f)
        {
            controlanimaciones.SetBool("correr", true);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") < -0.5f)
        {
            controlanimaciones.SetBool("correr", true);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            controlanimaciones.SetBool("correr", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
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
        if (Input.GetMouseButtonDown(0))
        {
            controlanimaciones.SetTrigger("ataque1");
            ataque1 = true;
            CDataque1 = currentCDataque1;
        }
        if (escudo == true)
        {
            controlanimaciones.SetTrigger("recibir_golpe");
            Instantiate(escudos, spawnescudo.transform.position, escudos.transform.rotation);
            CDescudo = currentCDescudo;
        }
        RotatePlayerAlongMousePosition();
        if (ataque2 == true)
        {
            controlanimaciones.SetTrigger("ataque1");
            Instantiate(atquecircular, spawnatquecircular.transform.position, atquecircular.transform.rotation);
            CDataque2 = currentCDataque2;
        }
        if (ataque3 == true)
        {
            controlanimaciones.SetTrigger("ataque2");
            Instantiate(boladefuego, spawnboladefuego.transform.position, boladefuego.transform.rotation);
            CDataque3 = currentCDataque3;
        }
        if (ataque4 == true)
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = camaraactual.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("plataforma"))
                {
                    Instantiate(rayo, hit.point, rayo.transform.rotation);
                    CDataque4 = currentCDataque4;
                }
            }
        }
        if (ataque5 == true)
        {

        }
        if (salto.velocity.y > 0.2f)
        {
            controlanimaciones.SetBool("salto", true);
            controlanimaciones.SetBool("caida", false);
        }
        else if (salto.velocity.y < -0.2f)
        {
            controlanimaciones.SetBool("salto", false);
            controlanimaciones.SetBool("caida", true);
        }
        else
        {
            controlanimaciones.SetBool("salto", false);
            controlanimaciones.SetBool("caida", false);
        }

    }
    void RotatePlayerAlongMousePosition()
    {

        mousePosition = camaraactual.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - camaraactual.transform.position.z));

        //Rotates toward the mouse
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg);

    }
}
