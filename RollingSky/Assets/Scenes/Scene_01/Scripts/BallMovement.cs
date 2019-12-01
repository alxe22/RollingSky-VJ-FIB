using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);
    private float degreesPerSecond = 120.0f;

    void Start()
    {
        //transform.rotation = Quaternion.Euler(90, 0, 0);
    }

	void Update ()
    {
        transform.position += (offset  * Time.deltaTime);
        transform.Rotate(Vector3.left * 250 * Time.deltaTime);
        //transform.Rotate(new Vector3(1, 0, 0) * degreesPerSecond * Time.deltaTime, Space.Self);
        //if (transform.position.y > 0.373f) transform.rotation = Quaternion.Euler(0, 90, 0);
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Pressed left click.");
            float horizontalMovement = Input.GetAxis("Mouse X");
            //Debug.Log(horizontalMovement);
            if (horizontalMovement > 0) 
            {
                transform.position += (new Vector3(-5f, 0f, 0f)  * Time.deltaTime);
            }
            else
            {
                transform.position += (new Vector3(5f, 0f, 0f)  * Time.deltaTime);
            }
        }
        if(Input.GetKey("d")) {
            transform.position += (new Vector3(-5f, 0f, 0f)  * Time.deltaTime);
            //transform.Rotate(new Vector3(0, 1, 1) * 20f * Time.deltaTime, Space.Self);
        }
        else if(Input.GetKey("a")) {
            transform.position += (new Vector3(5f, 0f, 0f)  * Time.deltaTime);
            //transform.Rotate(new Vector3(0, 1, 1) * -20f * Time.deltaTime, Space.Self);
        }
    }
}
