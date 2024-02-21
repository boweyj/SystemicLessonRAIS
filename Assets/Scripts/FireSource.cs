using UnityEngine;

public class FireSource : MonoBehaviour
{
    [SerializeField] private float fireRange;
    [SerializeField] private bool is2D;

    private EmitterBase emitter;
    void Awake()
    {
        if (is2D)
            emitter = gameObject.AddComponent(typeof(Emitter2D)) as Emitter2D;
        else
            emitter = gameObject.AddComponent(typeof(Emitter3D)) as Emitter3D;
        // TODO: extend to 3D emitter

        emitter.SetParameters(0.1f, fireRange, "fire");
    }
}
