using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTileJump : MonoBehaviour
{
    private Vector3 player;
    private int hasBeenActivated = 0;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        GameObject p = GameObject.Find("Player");
        this.player = p.transform.position;
        int zPos = (int)this.player.z;
        /*if(transform.position.z > -103) {
            Debug.Log("pos player " + player.z + " pos tile " + transform.position.z + " z " + zPos);
        }*/
        if (hasBeenActivated == 0 && zPos == transform.position.z && this.player.y <= 0.38f && ((int)this.player.x) == transform.position.x)
        {
            //Debug.Log("pos player " + player.z + " pos tile " + transform.position.z + " z " + zPos);
            Debug.Log("JUMP");
            p.GetComponent<Rigidbody>().AddForce(0, 150, 0);
            hasBeenActivated = 1;
        }
    }
}
