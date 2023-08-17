using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
{
    [SerializeField] int Vida;
    [SerializeField] float Velocidad;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;


        rb.AddForce(transform.forward * Velocidad);
    }

    public void Dañar(int cantidad)
    {
        Vida -= cantidad;
        if (Vida <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<AsteroidMecanics>().Sumar();
            Destroy(gameObject);
        }
    }
}
