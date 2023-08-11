using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] GameObject Player;
    NavMeshAgent Agent;
    [SerializeField] float Radio;


    [SerializeField] Transform[] Path;
    [SerializeField] bool RandomPath;
    [SerializeField] float NextCheckPoint;

    int currentWPObj;
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
            if (Vector3.Distance(transform.position, Path[currentWPObj].position) <= NextCheckPoint)
            {
                if (RandomPath)
                {
                    currentWPObj = Random.Range(0, Path.Length - 1);

                }
                else
                {
                    CheckPointIndex = CheckPointIndex == Path.Length - 1 ? 0 : CheckPointIndex + 1;
                    currentWPObj = CheckPointIndex;
                }
                Agent.SetDestination(Path[currentWPObj].position);
            }          
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
