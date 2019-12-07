using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);
    public float degreesPerSecond = 120.0f, maxJumpHeight = 4.6f;
    private bool isJumping = false, isFalling = false;
    private bool hasCollide = false;
    private bool ballDestroyed = false;
    public GameObject slicedBall1, slicedBall2, slicedBall3, slicedBall4;

    void Start()
    {
        //transform.rotation = Quaternion.Euler(90, 0, 0);
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

            if (Input.GetMouseButton(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Vector3 dir = hit.point - transform.position;
                dir.z = 0;
                dir.y = 0;
                transform.Translate(dir * Time.deltaTime*5, Space.World);

                // transform.Translate (dir * Time.DeltaTime * speed); // Try this if it doesn't work
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
        if (other.gameObject.name == "lv01-floor-arrow-jump(Clone)") {
            Debug.Log("Collision with: " + other.gameObject.name);
            if (!isJumping && !isFalling) isJumping = true;
        }
        // floor walls
        else if (other.gameObject.name == "lv01-wall-blue(Clone)" || 
                other.gameObject.name == "lv01-wall-green(Clone)" || 
                other.gameObject.name == "lv01-wall-red(Clone)" ||
                other.gameObject.name == "lv01-wall-orange(Clone)" ||
                other.gameObject.name == "lv01-wall-yellow(Clone)") {
            Debug.Log("Wall");
            obstacleCollision();
        }
        else if(other.gameObject.name == "floating-cube(Clone") {
            Debug.Log("Cube");
            obstacleCollision();
        }
        else if(other.gameObject.name == "lv01-obstacle-identity-disc(Clone)") {
            Debug.Log("identity disc");
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
