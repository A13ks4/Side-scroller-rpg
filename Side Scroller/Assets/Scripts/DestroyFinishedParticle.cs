using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys particle after it finishes
public class DestroyFinishedParticle : MonoBehaviour {

    private ParticleSystem particle;

    // Use this for initialization
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (particle.isPlaying)
        {
            return;
        }
        Destroy(gameObject);
    }
}
