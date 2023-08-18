using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPart : MonoBehaviour
{
    [SerializeField] GameObject SpawsEmpty;
    [SerializeField] MapGenerator MGe;

    private GameObject[] Spawns;
    private bool generado;

    private void Start()
    {
        //LLeno mi lista de spawns con todos los hijos de SpawnsEmpty
        GameObject[] aux = new GameObject[SpawsEmpty.transform.childCount];
        int i = 0;
        foreach (Transform child in SpawsEmpty.transform)
        {
            aux[i] = child.gameObject;
            i++;
        }
        Spawns = aux;
        //


        //Setteo variables a vlaor inicial
        MGe = GameObject.FindGameObjectWithTag("MapGenerator").GetComponent<MapGenerator>();
        generado = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !generado)
        {
            //Spawneo un objeto random en cada uno de los spaws de mi objeto
            foreach (GameObject Spwn in Spawns)
            {
                MGe.GenerarParte(Spwn.transform.position);
            }
            generado = true;
        }
    }



}
