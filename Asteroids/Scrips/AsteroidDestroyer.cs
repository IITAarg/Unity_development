using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class AsteroidDestroyer : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Asteroid>())
        {

            other.gameObject.GetComponent<Asteroid>().Dañar(1);
            Destroy(gameObject);
        }
    }

}
