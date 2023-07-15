using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Piano : MonoBehaviour
{
    public List<GameObject> teclas;
    public List<Material> Materials;
    public Image ImagenColorCorrecto;

    public JugadorPiano Jugador;

    public PianoTrackController Controller;
    public void pintar()
    {
        System.Random rnd = new System.Random();

        var teclasTemp = teclas;
        List<Material> temp=Materials;
        Tecla teclaActual;

        foreach (GameObject tecla in teclas)
        {
            tecla.AddComponent<Tecla>();
        }
        int TeclaCorrecta = rnd.Next(0, temp.Count);
        teclas[TeclaCorrecta].GetComponent<Tecla>().Set_TeclaCorrecta();

        foreach (GameObject tecla in teclas)
        {
            
            int index=rnd.Next(0, temp.Count);
            tecla.GetComponent<MeshRenderer>().material = temp[index];
            teclaActual = tecla.GetComponent<Tecla>();
            teclaActual.Jugador = this.Jugador;
            teclaActual.Controller = this.Controller;
            if (teclaActual.Get_TeclaCorrecta())
            {
                ImagenColorCorrecto.color = temp[index].color;
            }
            temp.RemoveAt(index);
            

        }

    }
}
