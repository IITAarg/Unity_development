using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] GameObject Player;
    NavMeshAgent Agent;
    [SerializeField] float Radio;


    [SerializeField] Transform[] RutaIdle;
    [SerializeField] float NextCheckPoint;
    int CheckPointIndex = 0;

    bool SeguirRuta = true;
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        SeguirRuta = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (EnCampoDeVision(Player))
        {
            Agent.SetDestination(Player.transform.position);
        }
        else
        {
            if (Vector3.Distance(transform.position, RutaIdle[CheckPointIndex].position) <= NextCheckPoint)
            {
                CheckPointIndex = CheckPointIndex == RutaIdle.Length - 1 ? 0 : CheckPointIndex + 1;
            }
            Agent.SetDestination(RutaIdle[CheckPointIndex].position);
        }
    }
    bool EnCampoDeVision(GameObject Objeto)
    {
        bool Cond1 = Vector3.Distance(transform.position, Objeto.transform.position) < Radio;
        bool Cond2 = false;
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, Objeto.transform.position - transform.position, out Hit, Radio))
        {

            Cond2 = Hit.collider.gameObject == Player;

        }
        return Cond1 && Cond2;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radio);
    }
}
