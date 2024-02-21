using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter3D : EmitterBase
{
    protected override void EmitMessage()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, broadcastRange);

        foreach (Collider c in targets)
        {
            EmissionReceiver r = c.GetComponent<EmissionReceiver>();
            if (r != null)
                r.ReceiveMessage(channel);
        }
    }
}
