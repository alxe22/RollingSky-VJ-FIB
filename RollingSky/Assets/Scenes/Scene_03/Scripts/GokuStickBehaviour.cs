using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuStickBehaviour : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 offset = new Vector3(0.0f, 0.0f, 7.0f);
    Vector3 originPos;
    // Start is called before the first frame update
    void Awake()
    {
      originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      float playerPosition = playerTransform.position.z * (-1f);
      float obstaclePosition = transform.position.z * (-1f);
      if (originPos.z*(-1) - playerPosition > 50) transform.position = originPos;
      else transform.position += (offset  * Time.deltaTime);
    }
}
