using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCorpBehaviour : MonoBehaviour
{
    public Transform playerTransform;
    private Quaternion originalRotation;

    private Vector3 originPosition;
	private Quaternion originRotation;


    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        float playerPosition = playerTransform.position.z * (-1f);
        float obstaclePosition = transform.position.z * (-1f);
        originPosition = transform.position;
		      originRotation = transform.rotation;
        if (obstaclePosition - playerPosition <= 1f) {
            transform.rotation = originalRotation;
            if(transform.position.y > 0.8f) transform.position = new Vector3(transform.position.x, transform.position.y-0.25f, transform.position.z);
        }
        else if (obstaclePosition - playerPosition <= 20) transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
    }
}
