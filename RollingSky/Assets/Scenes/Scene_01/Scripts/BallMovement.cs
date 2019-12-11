using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);
    public float degreesPerSecond = 120.0f, maxJumpHeight = 4.6f;
    private bool isJumping = false, isFalling = false;
    private bool hasCollide = false;
    private bool ballDestroyed = false;
    public GameObject slicedBall1, slicedBall2, slicedBall3, slicedBall4;
    private bool finish = false;
    private bool dead = false;
    private bool GOD = false;
    public GameObject BackGround;
    private int checkpoint = 0;
    public Text Retry;
    public Text Finish;
    public Text GodMode;


    void Start()
    {
        Physics.gravity = new Vector3(0, -100.0f, 0);
        GodMode.transform.localScale = new Vector3(0,0,1);
        //Finish.transform.localScale = new Vector3(0,0,1);
        Retry.transform.localScale = new Vector3(0,0,1);
    }

	void Update ()
    {
        if(transform.position.z < -86) checkpoint = 1;
        if(transform.position.z < -172) checkpoint = 2;
        if(transform.position.z < -251) checkpoint = 3;
        if(transform.position.z < -342) checkpoint = 4;
        if(Input.GetKey("l") && Input.GetKey("o") && Input.GetKey("k") && Input.GetKey("i")) {
          GOD = true;
          GodMode.transform.localScale = new Vector3(1,1,1);
          this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        if(Input.GetKey("a") && Input.GetKey("s") && Input.GetKey("k")) {
          GOD = false;
          GodMode.transform.localScale = new Vector3(0,0,1);
          this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        if(dead) {
          if(Retry.transform.localScale.x < 1) Retry.transform.localScale = new Vector3(Retry.transform.localScale.x + 0.1f, Retry.transform.localScale.y + 0.1f, Retry.transform.localScale.z);
          if(Input.GetKey("space")) {
            hasCollide = false;
            if(checkpoint == 0) transform.position = new Vector3(0f,0.375f,0f);
            if(checkpoint == 1) transform.position = new Vector3(0f,0.375f,-86f);
            if(checkpoint == 2) transform.position = new Vector3(0f,0.375f,-172f);
            if(checkpoint == 3) transform.position = new Vector3(0f,0.375f,-251f);
            if(checkpoint == 4) transform.position = new Vector3(0f,0.375f,-342f);
            dead = false;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            slicedBall1.transform.position = new Vector3(-100,100,200);
            slicedBall2.transform.position = new Vector3(-100,100,200);
            slicedBall3.transform.position = new Vector3(-100,100,200);
            slicedBall4.transform.position = new Vector3(-100,100,200);
            ballDestroyed = false;
            Retry.transform.localScale = new Vector3(0.0f, 0.0f, Retry.transform.localScale.z);
          }
        }
        //goal condition
        if(transform.position.z < -428) {
          finish = true;

        }
        //fall condition
        if(transform.position.y < 0) dead = true;
        else if (!hasCollide && !finish) {
            if(!(Input.GetKey("p") && GOD)) {
              transform.position += (offset  * Time.deltaTime);
              transform.Rotate(Vector3.left * 1000 * Time.deltaTime);
              if (isJumping || isFalling) {
                  this.gameObject.GetComponent<Rigidbody>().useGravity = false;
                  if (isJumping && !isFalling && transform.position.y < maxJumpHeight) {
                      transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
                  }
                  else if (isJumping && !isFalling && transform.position.y >= maxJumpHeight) {
                      isJumping = false;
                      isFalling = true;
                  }
                  else if (!isJumping && isFalling && transform.position.y > 0.375f) {
                      transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
                  }
                  else if (!isJumping && isFalling && transform.position.y <= 0.375f) {
                      isJumping = false;
                      isFalling = false;
                      transform.position = new Vector3(transform.position.x, 0.375f, transform.position.z);
                  }
              }
              else if(!GOD) this.gameObject.GetComponent<Rigidbody>().useGravity = true;

              if (Input.GetMouseButton(0)) {
                  Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
                  Vector3 PosObj = Camera.main.ScreenToWorldPoint(mouse);
                  transform.position = new Vector3(-PosObj.x/8, transform.position.y, transform.position.z);
              }
              if(Input.GetKey("d")) {
                  transform.position += (new Vector3(-5f, 0f, 0f)  * Time.deltaTime);
              }
              else if(Input.GetKey("a")) {
                  transform.position += (new Vector3(5f, 0f, 0f)  * Time.deltaTime);
              }
            }
        }
        else if(!finish) {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (!ballDestroyed) {
                ballDestroyed = true;
                slicedBall1.transform.position = transform.position;
                slicedBall2.transform.position = transform.position;
                slicedBall3.transform.position = transform.position;
                slicedBall4.transform.position = transform.position;
                dead = true;
            }
        }
        if(!dead && !finish) BackGround.transform.position = new Vector3(0.0f,-36, transform.position.z - 60);
    }

    void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "lv01-floor-arrow-jump(Clone)") {
            if (!isJumping && !isFalling) isJumping = true;
        }
        // floor walls
        else if (other.gameObject.name == "lv01-wall-blue(Clone)" ||
                other.gameObject.name == "lv01-wall-green(Clone)" ||
                other.gameObject.name == "lv01-wall-red(Clone)" ||
                other.gameObject.name == "lv01-wall-orange(Clone)" ||
                other.gameObject.name == "yellow_wall") {
            obstacleCollision();
        }
        else if(other.gameObject.name == "floating-cube(Clone") {
            obstacleCollision();
        }
        else if(other.gameObject.name == "lv01-obstacle-identity-disc(Clone)") {
            obstacleCollision();
        }
        else if(other.gameObject.name == "floating-cube(Clone)") {
          obstacleCollision();
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }

    private void obstacleCollision() {
        if(!GOD) hasCollide = true;
    }
}
