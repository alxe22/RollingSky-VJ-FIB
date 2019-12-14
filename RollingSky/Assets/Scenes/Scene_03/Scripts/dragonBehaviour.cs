using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonBehaviour : MonoBehaviour
{
    private bool isMovingLeft = true;
    private float speed = 0.01f;
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
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        else {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -2f) isMovingLeft = true;
        else if(transform.position.x >= 2f) isMovingLeft = false;
    }
}
