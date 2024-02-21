using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterBase : MonoBehaviour
{
    [SerializeField] protected float emitFrequency;
    [SerializeField] protected float broadcastRange;
    [SerializeField] protected string channel;

    private IEnumerator emissionCoroutine;

    private void Awake()
    {
        emissionCoroutine = CoEmit();
    }

    public void SetParameters(float freq, float range, string ch)
    {
        emitFrequency = freq;
        broadcastRange = range;
        channel = ch;
        StartCoroutine(emissionCoroutine);
    }

    private IEnumerator CoEmit()
    {
        while(true)
        {
            EmitMessage();
            yield return new WaitForSeconds(emitFrequency);
        }
    }

    protected virtual void EmitMessage()
    {
        // nothing here, override in subclass to customize emission
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, this.broadcastRange);
    }
}
