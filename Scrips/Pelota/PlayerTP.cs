using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTP : MonoBehaviour
{
    public Transform PuntoDeAparicion;
    public string SiguienteNivel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            gameObject.transform.position = PuntoDeAparicion.position;
        }


        if(other.gameObject.tag == "Ganar")
        {
            SceneManager.LoadScene(SiguienteNivel);
        }



    }
}
