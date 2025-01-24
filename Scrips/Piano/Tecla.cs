using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Tecla : ObjetoInteractivo
{
    bool TeclaCorrecta=false;

    public JugadorPiano Jugador;

    public PianoTrackController Controller;

    public override void Interactuar()
    {
        if (!TeclaCorrecta)
        {
            Jugador.PerderVida();
            
        }
        Controller.Next();
    }
    public void Set_TeclaCorrecta()
    {
        this.TeclaCorrecta = true;
    }

    public bool Get_TeclaCorrecta()
    {
        return this.TeclaCorrecta;
    }
}
