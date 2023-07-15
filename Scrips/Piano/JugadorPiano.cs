using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorPiano : MonoBehaviour
{
    public int Vida;

    public KeyCode Interaccion;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Interaccion))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.GetComponent<ObjetoInteractivo>() != null)
                {
                    hit.collider.gameObject.GetComponent<ObjetoInteractivo>().Interactuar();
                }
            }
        }
    }

    public void PerderVida()
    {
        Vida = Vida - 1;
        if (Vida <= 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        print("muerto");
        Time.timeScale = 0;
    }
}
