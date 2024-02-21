using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EmissionReceiver
{
    void ReceiveMessage(string channel);
}
