using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TrackController : MonoBehaviour
{
    [SerializeField] CinemachineSmoothPath Track;
    [SerializeField] CinemachineDollyCart Cart;

    [SerializeField] float rango = 0.02f;
    [SerializeField] float TiempoEspera = 10;

    int Poss=1;
    float speed;
    
    CinemachineSmoothPath.Waypoint[] Waypoints;
    // Start is called before the first frame update
    void Start()
    {
        //Obtengo los waypoints
        Waypoints = Track.m_Waypoints;
        speed = Cart.m_Speed;
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
            print(Waypoints.Length);
            print(Poss);
            distancia = Cart.gameObject.transform.position - (Track.gameObject.transform.position + Waypoints[Poss].position);
            //Si la distancia es menor al rango, se detiene al cart
            if (Mathf.Abs(distancia.x) <= rango && Mathf.Abs(distancia.y) <= rango && Mathf.Abs(distancia.z) <= rango)
            {
                StartCoroutine(Esperar(TiempoEspera, speed));
                Cart.m_Speed = 0;

                Poss += 1;
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Waypoints = Track.m_Waypoints;
        Gizmos.color = Color.white;

        if (Waypoints.Length > Poss)
        {
            Gizmos.DrawWireSphere(Track.gameObject.transform.position + Waypoints[Poss].position, rango);
        }
    }

    IEnumerator Esperar(float time,float speed)
    {
        yield return new WaitForSeconds(time);
        Cart.m_Speed=speed;
    }

}
