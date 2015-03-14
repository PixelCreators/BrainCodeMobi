using UnityEngine;
using System.Collections;

[RequireComponent(typeof (ParticleSystem))]

public class DestroyParticleAfterScript : MonoBehaviour
{
    private ParticleSystem particleSystemComponent;

    //Jeśli różne od zera to cząsteczka jest niszczona po danym czasie.
    public float DestroyParticleAfterTime = 0f;

    private void Awake()
    {
        particleSystemComponent = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (DestroyParticleAfterTime > 0)
            Destroy(this.gameObject, DestroyParticleAfterTime);
        else
            if (!particleSystemComponent.isPlaying)
                Destroy(this.gameObject);

    }
}