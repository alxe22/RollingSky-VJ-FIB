using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesBehaivour : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.z - transform.position.z <= 3) transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        else if(Player.transform.position.z > transform.position.z) transform.position = new Vector3(transform.position.x, - 0.1f, transform.position.z);
    }
}
