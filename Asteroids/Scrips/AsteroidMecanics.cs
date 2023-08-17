using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsteroidMecanics : MonoBehaviour
{
    [SerializeField] TextMeshPro TextoCantidadAsteroides;
    [SerializeField] Sprite[] Imagenes;
    [SerializeField] GameObject PanelCorazon;
    [SerializeField] string Scene;

    int Vida;

    private void Start()
    {
        foreach ( Transform child in PanelCorazon.transform)
        {
            child.GetComponent<Image>().sprite = Imagenes[0];
        }

        Vida = PanelCorazon.transform.childCount - 1;
    }

    public void Sumar()
    {
        int PUNTAJE = Int32.Parse(TextoCantidadAsteroides.text) + 1;
        TextoCantidadAsteroides.text = PUNTAJE.ToString();
    }

    void PerderVida()
    {

        if(Vida == -1)
        {
            SceneManager.LoadScene(Scene);
        }
        else
        {
            PanelCorazon.transform.GetChild(Vida).GetComponent<Image>().sprite = Imagenes[1];
            Vida--;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject Obj = other.gameObject;
        if (Obj.GetComponent<Asteroid>())
        {
            Destroy(Obj);
            PerderVida();
        }
    }

}
