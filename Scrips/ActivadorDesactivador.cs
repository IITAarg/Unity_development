using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorDesactivador : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Hold;
    public KeyCode ActionKey;
    [SerializeField] GameObject obj;

    private void Update()
    {

        if (Input.GetKeyDown(ActionKey))
        {
            if (Hold)
            {
                StartCoroutine(WaitTillRelease());
            }
            else
            {
                obj.SetActive(!obj.activeSelf);
            }
           
        }
      
       
    }

    IEnumerator WaitTillRelease()
    {
        obj.SetActive(true);
        yield return new WaitUntil(()=>(Input.GetKeyUp(ActionKey)));
        obj.SetActive(false);
    }

}
