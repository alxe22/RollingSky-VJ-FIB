using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement_lv02 : MonoBehaviour
{
    Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);
    public float degreesPerSecond = 120.0f, maxJumpHeight = 4.6f;
    private bool isJumping = false, isFalling = false;
    private bool hasCollide = false;
    private bool ballDestroyed = false;
    public GameObject slicedBall1, slicedBall2, slicedBall3, slicedBall4;

    void Start()
    {
        Physics.gravity = new Vector3(0, -100.0f, 0);
    }

	void Update ()
    {
        if (!hasCollide) {
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

            if (Input.GetMouseButton(0)) {
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
        else {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (!ballDestroyed) {
                ballDestroyed = true;
                slicedBall1.transform.position = transform.position;
                slicedBall2.transform.position = transform.position;
                slicedBall3.transform.position = transform.position;
                slicedBall4.transform.position = transform.position;
            }
        }
    }

    void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "lv02-floor-pipe(Clone)") {
            Debug.Log("Collision with: " + other.gameObject.name);
            if (!isJumping && !isFalling) isJumping = true;
        }
        else if (other.gameObject.name == "bullet-bill(Clone)") {
            Debug.Log("Collision with: " + other.gameObject.name);
            obstacleCollision();
        }
        else if (other.gameObject.name == "thwomp(Clone)") {
            Debug.Log("Collision with: " + other.gameObject.name);
            obstacleCollision();
        }
        else if(other.gameObject.name == "Bob-omb") {
            Debug.Log("Collision with: " + other.gameObject.name);
            obstacleCollision();
        }
        else {
            Debug.Log("There is any collision behaivour for: " + other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }

    private void obstacleCollision() {
         hasCollide = true;
    }
}
