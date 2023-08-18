using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class ItemColector : MonoBehaviour
{

    [SerializeField] int CantidaMaximaGemas;
    [SerializeField] TextMeshPro Texto;
    [SerializeField] AudioClip Sound;
    AudioSource SoundSource;


    private void Start()
    {
        Texto.text = CantidaMaximaGemas.ToString();
        SoundSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "item")
        {
            Destroy(other.gameObject);
            CantidaMaximaGemas--;
            Texto.text = CantidaMaximaGemas.ToString();
            SoundSource.PlayOneShot(Sound);
        }
    }

}
