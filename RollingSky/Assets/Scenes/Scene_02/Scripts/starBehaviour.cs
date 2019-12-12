using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starBehaviour : MonoBehaviour
{
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;

    public GameObject particleSystemContainer;
    public GameObject defaultMat;

    private bool collisionParticlesActivated = false;


    ParticleSystem ps;

    void Awake()
    {
        ps = particleSystemContainer.GetComponent<ParticleSystem>();
        ps.Stop();
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            if (!collisionParticlesActivated) {
                ps.Play();
                defaultMat.GetComponent<MeshRenderer>().enabled = false;
                collisionParticlesActivated = true;
            }
            Debug.Log("entered");
            Destroy(gameObject, 0.3f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }
}
