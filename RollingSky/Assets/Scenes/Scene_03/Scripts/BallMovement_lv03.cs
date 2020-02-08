using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BallMovement_lv03 : MonoBehaviour
{
    Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);
    public float degreesPerSecond = 120.0f, maxJumpHeight = 4.6f;
    private bool isJumping = false, isFalling = false;
    private bool hasCollide = false;
    private bool ballDestroyed = false;
    public GameObject slicedBall1, slicedBall2, slicedBall3, slicedBall4;
    private bool finish = false;
    private bool dead = false;
    private Vector3 deadPos;
    private bool GOD = false;
    public GameObject BackGround;
    private int checkpoint = 0;
    private bool started = false;
    public RawImage Retry;
    public RawImage Finish;
    public Text GodMode;
    public Text StartText;
    public AudioClip BackMusic;
    public AudioClip SoundCol;
    public AudioClip FinishSound;
    public AudioSource ColSound;
    public AudioSource Music;
    public AudioSource SoundFinish;

    void Start()
    {
      Physics.gravity = new Vector3(0, -100.0f, 0);
      GodMode.transform.localScale = new Vector3(0,0,1);
      Finish.transform.localScale = new Vector3(0,0,1);
      Retry.transform.localScale = new Vector3(0,0,1);
      Music.clip = BackMusic;
      ColSound.clip = SoundCol;
      SoundFinish.clip = FinishSound;
      deadPos = new Vector3(0,0,0);
    }

	void Update ()
  {
    if(Input.GetKey(KeyCode.Escape)) UnityEngine.SceneManagement.SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    if(!started) {
      StartText.transform.localScale = new Vector3(1,1,1);
      transform.Rotate(Vector3.left * 1000 * Time.deltaTime);
      if (Input.GetKey("space")) {
        started = true;
        Music.Play(0);
        StartText.transform.localScale = new Vector3(0,0,0);
      }
    }
    else {
      if(transform.position.z < -109) checkpoint = 1;
      if(transform.position.z < -212) checkpoint = 2;
      if(transform.position.z < -290) checkpoint = 3;
      if(Input.GetKey("l")) {
        GOD = true;
        GodMode.transform.localScale = new Vector3(1,1,1);
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
      }
      if(Input.GetKey("g")) {
        GOD = false;
        GodMode.transform.localScale = new Vector3(0,0,1);
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
      }
      if(dead) {
        Music.Pause();
        transform.position = new Vector3(transform.position.x, transform.position.y,deadPos.z);
        if(Retry.transform.localScale.x < 6) Retry.transform.localScale = new Vector3(Retry.transform.localScale.x + 0.4f, Retry.transform.localScale.y + 0.4f, Retry.transform.localScale.z);
        if(Input.GetKey("space")) {
          Music.Play(0);
          hasCollide = false;
          if(checkpoint == 0) transform.position = new Vector3(0f,0.375f,0f);
          if(checkpoint == 1) transform.position = new Vector3(0f,0.375f,-110f);
          if(checkpoint == 2) transform.position = new Vector3(0f,0.375f,-215f);
          if(checkpoint == 3) transform.position = new Vector3(0f,0.375f,-291f);
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
      if(transform.position.z < -402) {
        Music.Pause();
        if(!finish) SoundFinish.Play(0);
        finish = true;
        if(Finish.transform.localScale.x < 6) Finish.transform.localScale = new Vector3(Finish.transform.localScale.x + 0.4f, Finish.transform.localScale.y + 0.4f, Finish.transform.localScale.z);
        if(Input.GetKey("space")) {
          UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_03", LoadSceneMode.Single);
        }
      }
      //fall condition
      if(transform.position.y < -2) {
        dead = true;
        deadPos = transform.position;
      }
      else if (!hasCollide && !finish) {
          if(!(Input.GetKey("p") && GOD)) {
            transform.position += (offset  * Time.deltaTime);
            transform.Rotate(Vector3.left * 1000 * Time.deltaTime);
            if (isJumping || isFalling) {
                this.gameObject.GetComponent<Rigidbody>().useGravity = false;
                if (isJumping && !isFalling && transform.position.y < maxJumpHeight) {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 18f*Time.deltaTime, transform.position.z);
                }
                else if (isJumping && !isFalling && transform.position.y >= maxJumpHeight) {
                    isJumping = false;
                    isFalling = true;
                }
                else if (!isJumping && isFalling && transform.position.y > 0.375f) {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 18f*Time.deltaTime, transform.position.z);
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
  }

    void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "lv03-floor-jumping-tile(Clone)") {
            if (!isJumping && !isFalling) isJumping = true;
        }
        else if (other.gameObject.name == "goku-stick(Clone)") {
            obstacleCollision();
        }
        else if (other.gameObject.name == "corp(Clone)") {
            obstacleCollision();
        }
        else {
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "kamehameha") {
            obstacleCollision();
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }

    private void obstacleCollision() {
      if(!GOD) {
        deadPos = transform.position;
        hasCollide = true;
        Music.Pause();
        ColSound.Play(0);
      }
    }
}
