using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission1 : Task
{
    // Start is called before the first frame update
    public override void Accept()
    {
        print("Mission1 aceptada");
    }
    public override void Decline()
    {
        print("Mission1 rechazada");
    }

    public override void Complete()
    {
        throw new System.NotImplementedException();
    }
}
