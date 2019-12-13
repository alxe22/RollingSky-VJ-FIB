using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBillBehaivour : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 offset = new Vector3(0.0f, 0.0f, 10.0f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      float playerPosition = playerTransform.position.z * (-1f);
      float obstaclePosition = transform.position.z * (-1f);
      if (obstaclePosition - playerPosition <= 50) transform.position += (offset  * Time.deltaTime);
    }
}
