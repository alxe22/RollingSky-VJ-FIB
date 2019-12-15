using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCorpBehaviour : MonoBehaviour
{
    public Transform playerTransform;
    private Quaternion originalRotation;

    private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay = 0.002f;
	public float shake_intensity = .3f;
	private float temp_shake_intensity = 0;

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
        if (obstaclePosition - playerPosition <= 0f) {
            transform.rotation = originalRotation;
            if(transform.position.y > 0.8f) transform.position = new Vector3(transform.position.x, transform.position.y-0.03f, transform.position.z);
        }
    }
}
