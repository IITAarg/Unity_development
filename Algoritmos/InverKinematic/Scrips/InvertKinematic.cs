using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static Unity.Burst.Intrinsics.X86;

public class InvertKinematic : MonoBehaviour
{
    [SerializeField]
    Transform[] bones;
    float[] bonesLengths;

    [SerializeField]
    int solverIterations;

    [SerializeField]
    Transform targetPosition;

    private void Start()
    {
        bonesLengths = new float[bones.Length];

        for (int i = 0; i < bones.Length; i++)
        {
            if (i < bones.Length - 1)
            {
                bonesLengths[i] = (bones[i + 1].position - bones[i].position).magnitude;

            }
            else
            {
                bonesLengths[i] = 0f;
            }
        }
    }
    private void FixedUpdate()
    {
        Solve();
    }
    void Solve()
    {
        Vector3[] finalBonesPositions = new Vector3[bones.Length];

        for(int i = 0; i < bones.Length; i++)
        {
            finalBonesPositions[i] = bones[i].position;
        }


        for (int i = 0; i < solverIterations; i++)
        {
            finalBonesPositions = SolveForwardPositions(SolveInversePositions(finalBonesPositions));
        }

        for(int i = 0; i < bones.Length; i++)
        {

            
            bones[i].position = finalBonesPositions[i];
            
            if(i != bones.Length - 1)
            {
                bones[i].rotation = Quaternion.LookRotation(finalBonesPositions[i + 1] - bones[i].position);
            }
            else
            {
                bones[i].rotation = Quaternion.LookRotation(targetPosition.position - bones[i].position);
            }
        }
    }


    Vector3[] SolveInversePositions(Vector3[] forwardPositions)
    {
        Vector3[] inversePositions = new Vector3[forwardPositions.Length];

        for (int i = (forwardPositions.Length - 1); i >= 0; i--)
        {
            if (i == forwardPositions.Length - 1)
            {
                inversePositions[i] = targetPosition.position;
            }
            else
            {
                Vector3 posPrimaSiguiente = inversePositions[i + 1];
                Vector3 posBaseActual = forwardPositions[i];
                Vector3 direccion = (posBaseActual - posPrimaSiguiente).normalized;
                float longitud = bonesLengths[i];
                inversePositions[i] = posPrimaSiguiente + (direccion * longitud);
            }
        }




        return inversePositions;
    }

    Vector3[] SolveForwardPositions(Vector3[] inversePositions)
    {
        Vector3[] forwardPositions = new Vector3[inversePositions.Length];

        for (int i = 0; i < inversePositions.Length; i++)
        {
            if (i == 0)
            {
                forwardPositions[i] = bones[0].position;
            }
            else
            {
                Vector3 posPrimaActual = inversePositions[i];
                Vector3 posPrimaSegundaAnterior = forwardPositions[i - 1];
                Vector3 direccion = (posPrimaActual - forwardPositions[i - 1]).normalized;
                float longitud = bonesLengths[i - 1];
                forwardPositions[i] = posPrimaSegundaAnterior + (direccion * longitud);
            }
        }



        return forwardPositions;
    }



}



