using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Task : MonoBehaviour
{

    public abstract void Accept();

    public abstract void Decline();

    public abstract void Complete();
}
