using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField] bool Randomize;
    [SerializeField] GameObject[] Parts;
    private int PartNumber;
    public void GenerarParte(Vector3 pos)
    {
        int index;
        if (Randomize)//Genero un numero aleatorio
        {
            index = Random.Range(0, Parts.Length - 1);

        }
        else //Hago una sucesion de numeros desde 0 hasta el largo de la lista "Parts". Si es igual que el largo 
            //Seteo en 0
        {
            index = PartNumber == Parts.Length ? 0 : PartNumber + 1;
        }
        Instantiate(Parts[index], pos, Quaternion.identity);


    }


}
