using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaterLevel : MonoBehaviour {


	[SerializeField] private Water water;
	[SerializeField] private float offset = 0.3f;
	Vector3 tiltAngle;

	
	// Update is called once per frame
	void Update () {
		Vector3 waterYPositions = water.VertexPositionAroundX(transform.position.x);
		float yPosition = transform.position.y;
		yPosition = Mathf.Lerp(yPosition, waterYPositions.y, Time.fixedDeltaTime * 10.0f);
		yPosition += offset;

		
		transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);

		Vector3 setOne = new Vector3(0, waterYPositions.x, 0);
		Vector3 setTwo = new Vector3(1, waterYPositions.z, 0);
		tiltAngle = Vector3.Lerp(tiltAngle, setTwo - setOne, Time.fixedDeltaTime * 20.0f);
		transform.forward = tiltAngle;

	}
}
