using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);
    public float degreesPerSecond = 120.0f, maxJumpHeight = 4.6f;
    private bool isJumping = false, isFalling = false;

    void Start()
    {
        Physics.gravity = new Vector3(0, -100.0f, 0);
    }

	void Update ()
    {
        transform.position += (offset  * Time.deltaTime);
        transform.Rotate(Vector3.left * 1000 * Time.deltaTime);
        if (isJumping || isFalling) {
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            if (isJumping && !isFalling && transform.position.y < maxJumpHeight) {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z);
            }
            else if (isJumping && !isFalling && transform.position.y >= maxJumpHeight) {
                isJumping = false;
                isFalling = true;
            }
            else if (!isJumping && isFalling && transform.position.y > 0.375f) {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z);
            }
            else if (!isJumping && isFalling && transform.position.y <= 0.375f) {
                isJumping = false;
                isFalling = false;
                transform.position = new Vector3(transform.position.x, 0.375f, transform.position.z);
            }
        }
        else this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        //transform.Rotate(new Vector3(1, 0, 0) * degreesPerSecond * Time.deltaTime, Space.Self);
        //if (transform.position.y > 0.373f) transform.rotation = Quaternion.Euler(0, 90, 0);

        if (Input.GetMouseButton(0)){
          Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
          Vector3 PosObj = Camera.main.ScreenToWorldPoint(mouse);
          transform.position = new Vector3(-PosObj.x/8, transform.position.y, transform.position.z);
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

    void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "lv01-floor-arrow-jump(Clone)") {
            Debug.Log("Collision with: " + other.gameObject.name);
            if (!isJumping && !isFalling) isJumping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }
}
