using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDePuertas : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puerta")
        {
            other.gameObject.GetComponent<Animator>().Play("Abrir-Puerta");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "puerta")
        {
            other.gameObject.GetComponent<Animator>().Play("Cerrar-Puerta");
        }
    }
}

