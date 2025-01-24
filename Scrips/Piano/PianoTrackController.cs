using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PianoTrackController : MonoBehaviour
{
    [SerializeField] CinemachineSmoothPath Track;
    [SerializeField] CinemachineDollyCart Cart;

    [SerializeField] float rango = 0.02f;


    [SerializeField] JugadorPiano Jugador;

    [SerializeField] GameObject ArosGameObject;

    int Poss=1;
    int AroInd = 0;
    float speed;
    Piano[] Aros;


    CinemachineSmoothPath.Waypoint[] Waypoints;
    // Start is called before the first frame update
    void Start()
    {
        Aros = new Piano[ArosGameObject.transform.childCount];
        int i =0;
        foreach( Transform child in ArosGameObject.transform)
        {
            Aros[i] = child.GetComponent<Piano>();
            i++;
        }
        //Obtengo los waypoints
        Waypoints = Track.m_Waypoints;
        speed = Cart.m_Speed;
        Aros[AroInd].pintar();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 distancia = new Vector3(0, 0, 0);
        //Calculo la distancia entre el Cart y el siguiente waypint
        if (Waypoints.Length <= Poss && Track.Looped)
        {
            Poss = 0;
            
        }
        
        if(Waypoints.Length > Poss)
        {
            
            //print(Waypoints.Length);
            //print(Poss);
            distancia = Cart.gameObject.transform.position - (Track.gameObject.transform.position + Waypoints[Poss].position);
            //Si la distancia es menor al rango, se detiene al cart
            if (Mathf.Abs(distancia.x) <= rango && Mathf.Abs(distancia.y) <= rango && Mathf.Abs(distancia.z) <= rango)
            {
                Jugador.PerderVida();
                Next();
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Waypoints = Track.m_Waypoints;
        Gizmos.color = Color.white;

        if (Waypoints.Length > Poss)
        {
            //print("si");
            Gizmos.DrawWireSphere(Track.gameObject.transform.position + Waypoints[Poss].position, rango);
        }
    }

    public void Next()
    {
        Destroy(Aros[AroInd].gameObject);
        AroInd += 1;
        Poss += 1;
        if (AroInd < Aros.Length)
        {
            
            Aros[AroInd].pintar();
        }
        else
        {
            print("Ganaste");
            Time.timeScale = 0;
        }
    }

    IEnumerator Esperar(float time,float speed)
    {
        yield return new WaitForSeconds(time);
        Cart.m_Speed=speed;
    }

}
