using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using Unity.VisualScripting;
using UnityEngine.Experimental.GlobalIllumination;

//Scrip para hacer un auto. Requisitos:


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(KmH_Text_Controller))]
public class SimpleCarController : MonoBehaviour
{
    [SerializeField] List<AxleInfo> axleInfos; // the information about each individual axle
    [SerializeField] GameObject[] LucesFreno;
    [SerializeField] GameObject[] LucesAdelante;
    [SerializeField] float maxMotorTorque; // maximum torque the motor can apply to wheel
    [SerializeField] float maxSteeringAngle; // maximum steer angle the wheel can have
    [SerializeField] float BrakeForce;
    [SerializeField] float MotorBreak;
    [SerializeField] GameObject Frenada;

    bool Frenando;

    [HideInInspector] public Rigidbody rb;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AccionarLuzDelantera();
        }
        Frenando = Input.GetKey(KeyCode.Space);
    }
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);


            if (Frenando == true)
            {
                Frenar(axleInfo, BrakeForce);
                AccionarLuzDeFreno(true);
            }
            else
            {
                AccionarLuzDeFreno(false);
                axleInfo.leftWheel.brakeTorque = 0;
                axleInfo.rightWheel.brakeTorque = 0;
                if (axleInfo.motor)
                {
                    DeterminarFuerza(motor, axleInfo);
                    //axleInfo.leftWheel.motorTorque = motor;
                    //axleInfo.rightWheel.motorTorque = motor;
                }
            }
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            
            
        }
    }


    void DeterminarFuerza(float InputVertical,AxleInfo axis)
    {
        if(InputVertical == 0)
        {
            Frenar(axis, MotorBreak);
            //axis.leftWheel.motorTorque = 0;
            //axis.rightWheel.motorTorque = 0;
        }
        else
        {
            axis.leftWheel.motorTorque = InputVertical;
            axis.rightWheel.motorTorque = InputVertical;
        }
    }


    void Frenar(AxleInfo eje,float Intensidad)
    {
        eje.leftWheel.brakeTorque = Intensidad * 100;
        eje.rightWheel.brakeTorque = Intensidad * 100;
        if (rb.velocity.magnitude > 5 && Frenando)
        {
            Instantiate(Frenada, eje.LSkidMark.position, Quaternion.identity);
            Instantiate(Frenada, eje.RSkidMark.position, Quaternion.identity);
        }
        
    }
    void AccionarLuzDeFreno( bool accion)
    {
        foreach(GameObject Luz in LucesFreno)
        {
            Luz.SetActive(accion);
        }
    }
    void AccionarLuzDelantera()
    {
        foreach (GameObject Luz in LucesAdelante)
        {
            Luz.SetActive(!Luz.activeSelf);
        }
    }



    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public Transform LSkidMark;
    public Transform RSkidMark;


    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}