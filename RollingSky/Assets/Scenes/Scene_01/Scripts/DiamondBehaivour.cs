using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBehaivour : MonoBehaviour
{
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;

    void Awake()
    {
        // move and reduce the size of the cube
        //transform.position = new Vector3(0, 0.25f, 0.75f);
        //transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // add isTrigger
        //var boxCollider = gameObject.AddComponent<BoxCollider>();
        //boxCollider.isTrigger = true;

        //moveSpeed = 1.0f;

        // create a sphere for this cube to interact with
        /*GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.gameObject.transform.position = new Vector3(0, 0, 0);
        sphere.gameObject.AddComponent<Rigidbody>();
        sphere.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        sphere.gameObject.GetComponent<Rigidbody>().useGravity = false;*/
    }

    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
        //transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
        //transform.Rotate = transform.Rotate + Quaternion.Euler(20);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            Debug.Log("entered");
            //Destroy (transform.parent.gameObject, 0.1f); // destroy parent a few frames later;
            Destroy(gameObject, 0.1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit)
        {
            Debug.Log("exit");
        }
    }
}