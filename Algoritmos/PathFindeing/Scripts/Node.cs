using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> neighbours = new List<Node>();
    [SerializeField] Transform[] posible_neighbours;
    void Awake()
    {
        search_neighbours();
    }

    void search_neighbours()
    {
        //Update the neighbours to find the nearby neighbours with raycast
        foreach (Transform posible_neighbour in posible_neighbours)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, posible_neighbour.localPosition, out hit, 1f))
            {
                Node negthbour_node = hit.collider.gameObject.GetComponent<Node>();
                if (negthbour_node != null)
                {
                    neighbours.Add(negthbour_node);
                }
            }
        }

    }

}
