using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestTaskPanel : MonoBehaviour
{
    public Task RequestedTask;
    public void AcceptTask()
    {
        RequestedTask.Accept();
        HideObject();
    }

    public void DeclineTask()
    {
        RequestedTask.Decline();
        HideObject();
    }


    void HideObject()
    {
        gameObject.SetActive(false);
    }
}
