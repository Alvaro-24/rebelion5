using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inicio : MonoBehaviour
{
    public movimientoplayer player;
    public void iniciar()
    {
        SceneManager.LoadScene(1);
    }
    public void cerrarsesion()
    {
        Application.Quit();
    }
}
