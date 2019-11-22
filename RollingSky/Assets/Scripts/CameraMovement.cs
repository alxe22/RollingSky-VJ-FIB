using UnityEngine;

public class CameraMovement : MonoBehaviour {

	/*
	This class handles the camera movement by taking into an account the position of the player (cube) by adding
	an offset to the position of the camera so it follow the desired object as it moves through the road 
	*/

	public Transform transformPlayer;
	void Update () {
		//because the script is inside the camera, the transform.position refers to the transfrom of the camera
		transform.position = transform.position /*+ transformPlayer.position*/; //camera transfrom equals the position of the object
	}
}