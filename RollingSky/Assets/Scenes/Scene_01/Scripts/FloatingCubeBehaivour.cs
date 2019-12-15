using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCubeBehaivour : MonoBehaviour
{
    public Transform playerTransform;
    private Quaternion originalRotation;

    private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay = 0.002f;
	public float shake_intensity = .3f;
	private float temp_shake_intensity = 0;
  public float FallSpeed = 0.25f;

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
      temp_shake_intensity = shake_intensity;
      if (obstaclePosition - playerPosition <= 1) {
        transform.rotation = originalRotation;
        if(transform.position.y > 0.5f) transform.position = new Vector3(transform.position.x, transform.position.y-FallSpeed, transform.position.z);
      }
      else if (obstaclePosition - playerPosition <= 20 && obstaclePosition - playerPosition >= 0.1f && temp_shake_intensity > 0) {
        transform.rotation = new Quaternion(
        originRotation.x + Random.Range (-0.2f,0.2f) * .1f,
        originRotation.y + Random.Range (-0.2f,0.2f) * .1f,
        originRotation.z,
        originRotation.w);
        temp_shake_intensity -= shake_decay;
        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
      }
    }
}
