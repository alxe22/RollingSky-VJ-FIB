using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeBehaivour : MonoBehaviour
{
    private bool isMovingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x <= -2f) isMovingLeft = true;
        else isMovingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingLeft) {
            transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
        }
        else {
            transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -2f || transform.position.x >= 2f) {
            isMovingLeft = !isMovingLeft;
        }
    }
}
