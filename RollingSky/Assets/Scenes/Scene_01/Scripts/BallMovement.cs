using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);
    void Start()
    {
    }

	void Update ()
    {
        transform.position += (offset  * Time.deltaTime);
        if (transform.position.y > 0.373f) transform.rotation = Quaternion.Euler(0, 90, 0);
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Pressed left click.");
            float horizontalMovement = Input.GetAxis("Mouse X");
            Debug.Log(horizontalMovement);
            if (horizontalMovement > 0) 
            {
                transform.position += (new Vector3(-5f, 0, 0)  * Time.deltaTime);
            }
            else
            {
                transform.position += (new Vector3(5f, 0, 0)  * Time.deltaTime);
            }
        }
        if(Input.GetKey("d")) {
            transform.position += (new Vector3(-5f, 0, 0)  * Time.deltaTime);
        }
        else if(Input.GetKey("a")) {
            transform.position += (new Vector3(5f, 0, 0)  * Time.deltaTime);
        }
    }
}
