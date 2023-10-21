using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dijkstra : MonoBehaviour
{


    public Node First;
    public Node Last;
    public List<Node> FindShortestPath(Node startNode, Node endNode)
    {
        Dictionary<Node, float> distances = new Dictionary<Node, float>();
        Dictionary<Node, Node> previousNodes = new Dictionary<Node, Node>();
        List<Node> unvisitedNodes = new List<Node>();

        //
        foreach (Node node in FindObjectsOfType<Node>())
        {
            distances[node] = float.MaxValue;
            previousNodes[node] = null;
            unvisitedNodes.Add(node);
        }

        distances[startNode] = 0;

        while (unvisitedNodes.Count > 0)
        {
            //Sort the list with the nearst nodes first and the farder at last
            unvisitedNodes.Sort((previus, next) => distances[previus].CompareTo(distances[next]));
            Node currentNode = unvisitedNodes[0];
            unvisitedNodes.Remove(currentNode);

            if (currentNode == endNode) // The objetive node is reached
            {
                return ReconstructPath(endNode, previousNodes); 
            }

            foreach (Node neighbor in currentNode.neighbours)
            {
                float tentativeDistance = distances[currentNode] + Vector3.Distance(currentNode.transform.position, endNode.transform.position);

                if (tentativeDistance < distances[neighbor])
                {
                    distances[neighbor] = tentativeDistance;
                    previousNodes[neighbor] = currentNode;
                }
            }
        }

        return null; // No path found
    }

    List<Node> ReconstructPath(Node endNode, Dictionary<Node, Node> previousNodes)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;
        while (currentNode != null)
        {
            path.Insert(0, currentNode);
            currentNode = previousNodes[currentNode];
        }
        return path;
    }


    private void Start()
    {
        List<Node> shortest = FindShortestPath(First, Last);

        if(shortest == null)
        {
            print("null path");
        }
        else
        {
            foreach (Node N in shortest)
            {
                N.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
       
    }

}
