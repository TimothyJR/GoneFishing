using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

	[SerializeField] private Transform gameCamera;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(gameCamera.position.x, transform.position.y, transform.position.z);
	}
}
