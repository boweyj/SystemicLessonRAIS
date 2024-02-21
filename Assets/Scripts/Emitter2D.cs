using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter2D : EmitterBase
{
    protected override void EmitMessage()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, broadcastRange);

        foreach (Collider2D c in targets)
        {
            EmissionReceiver r = c.GetComponent<EmissionReceiver>();
            if (r != null)
                r.ReceiveMessage(channel);
        }
    }
}
