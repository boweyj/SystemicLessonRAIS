using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Burnable
{
    void TakeFireDamage(int d);
    void Ignite();
}
