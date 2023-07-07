using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Menu : MonoBehaviour
{

    [SerializeField] Animator TransitionANIM;
    [SerializeField] float Delay;

    [SerializeField] AudioClip ButtonSound;
    private AudioSource audiosrc;
    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }
    public void Cargar_Scena(string Nombre){
        audiosrc.PlayOneShot(ButtonSound);
        StartCoroutine(Cargar(Nombre));
    }
    public void Cerrar_Juego()
    {
        Application.Quit();
    }

    IEnumerator Cargar(string Nombre)
    {
        TransitionANIM.enabled = true;
        yield return new WaitUntil(() => TransitionANIM.GetCurrentAnimatorStateInfo(0).normalizedTime > 1);
        yield return new WaitForSeconds(Delay);
        SceneManager.LoadScene(Nombre);

    }
}
