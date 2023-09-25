using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVisionFPS : MonoBehaviour
{
    [SerializeField] float Rango;
    public KeyCode Interaccion;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Interaccion))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward,out hit, Rango))
            {
                if(hit.collider.gameObject.GetComponent<ObjetoInteractivo>()!= null)
                {
                    hit.collider.gameObject.GetComponent<ObjetoInteractivo>().Interactuar();
                }
            }
        }
    }
}
