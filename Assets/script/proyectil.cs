using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour
{
    [HideInInspector] public Vector3 direction;
    public float speed;
    Vector3 mousePosition;

    private void Start()
    {
        Destroy(this.gameObject, 5);
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));
        direction = (mousePosition - this.transform.position).normalized;

        Destroy(this.gameObject, 5); // si la bala pasa de 8 segundos se destruye

    }

    void Update()
    {
        this.transform.position += direction * speed * Time.deltaTime;
    }
}
