using UnityEngine;

//extends MonoBehaivour
public class TestPlayerMovement : MonoBehaviour {

/*
This class handles player movement
*/
	public Rigidbody rb;
	public int forwardForce = 7000;
	public int middle = Screen.width/2;
	
	void FixedUpdate () {
		rb.transform.rotation = Quaternion.Euler(0, 0, 0);
		rb.AddForce(0, 0, 750*Time.deltaTime);
	}
}