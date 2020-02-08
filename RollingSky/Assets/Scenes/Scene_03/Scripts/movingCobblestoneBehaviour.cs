using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCobblestoneBehaviour : MonoBehaviour
{
    public Transform playerTransform;
    private bool moving = false;
    private Vector3 initialPosition;
    private Vector3 endPosition;
    Vector3 originPos;
    Vector3 offset = new Vector3(0.0f, 0.0f, -9.0f);

    void Update()
    {
        float playerPosition = playerTransform.position.z * (-1f);
        float obsPosition = transform.position.z * (-1f);
        if (originPos.z*(-1) + 1 < playerPosition) transform.position = originPos;
        if (moving && endPosition.z <= transform.position.z) {
            transform.position +=  offset * Time.deltaTime;
        }
        else moving = false;
    }

    void Awake()
    {
        originPos = transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        initialPosition = transform.position;
        endPosition = transform.position;
        endPosition.z = endPosition.z - 1;
        moving = true;
    }
}
