using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobOmbBehaivour : MonoBehaviour
{
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;

    public GameObject defaultMat;

    private bool collisionParticlesActivated = false;

    private float degreesPerSecond = 90.0f;

    ParticleSystem ps;

    void Awake()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
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
            Destroy(gameObject, 0.3f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }
}
