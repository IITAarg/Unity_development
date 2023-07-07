using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Scrip para funcionar en conjunto con SimpleCarController. Este scrip escribe en un texto la velocidad que 
//tiene el Auto
public class KmH_Text_Controller : MonoBehaviour
{
    public Text Texto;
    private SimpleCarController CarController;
    private void Start()
    {
        CarController = GetComponent<SimpleCarController>();
    }
    // Update is called once per frame
    void Update()
    {
        Texto.text = ((int)(CarController.rb.velocity.magnitude * 3.6)).ToString();
    }
}

