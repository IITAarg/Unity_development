using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] GameObject[] ObjectToSpawn;

    [SerializeField] GameObject[] Spaws;

    [SerializeField] float TiempoDeAparicion;
    [SerializeField] float LifeTime;

    float timer;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= TiempoDeAparicion)
        {
            Spawnear();
            timer = 0;
        }
    }

    void Spawnear()
    {
        int numero = Random.Range(0, Spaws.Length);
        int objrandom = Random.Range(0, ObjectToSpawn.Length);

        GameObject obj = Instantiate(ObjectToSpawn[objrandom], Spaws[numero].transform.position, Quaternion.identity);
        Destroy(obj, LifeTime);
    }
}
