using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
	[SerializeField] private Water water;
	private bool canMove = true;
	float speed;
	Vector3 direction;
	Vector3 boatTiltAngle;
	[SerializeField] float boatSplashVelocity = 0.05f;
	[SerializeField] float moveSpeedIncrement = 0.2f;
	[SerializeField] float maxSpeed = 5.0f;
	
	public bool CanMove
	{
		set { canMove = value; }
	}

	private void FixedUpdate()
	{
		if(!canMove)
		{
			return;
		}
		if(Input.GetKey("a"))
		{
			speed += moveSpeedIncrement;
			direction.x = -1;
		}
		else if(Input.GetKey("d"))
		{
			speed += moveSpeedIncrement;
			direction.x = 1;
		}
		else
		{
			if(speed > 0)
			{
				speed -= moveSpeedIncrement * 2;
				if(speed < 0)
				{
					speed = 0;
				}
			}	
		}
		
		speed = Mathf.Clamp(speed, 0.0f, maxSpeed);


		Vector3 waterYPositions = water.VertexPositionAroundX(transform.position.x);
		float yPosition = transform.position.y;
		yPosition = Mathf.Lerp(yPosition, waterYPositions.y, Time.fixedDeltaTime * 10.0f);
		boatTiltAngle += direction;
		if(direction.x > 0)
		{
			Vector3 setOne = new Vector3(0, waterYPositions.x, 0);
			Vector3 setTwo = new Vector3(1, waterYPositions.z, 0);
			boatTiltAngle = Vector3.Lerp(boatTiltAngle, setTwo - setOne, Time.fixedDeltaTime * 20.0f);
		}
		else
		{
			Vector3 setOne = new Vector3(0, waterYPositions.x, 0);
			Vector3 setTwo = new Vector3(1, waterYPositions.z, 0);
			boatTiltAngle = Vector3.Lerp(boatTiltAngle, setOne - setTwo, Time.fixedDeltaTime * 20.0f);
		}

		if (speed != 0)
		{
			Vector3 velocity = direction;
			velocity.x *= speed;
			transform.position += velocity * Time.fixedDeltaTime;
			transform.forward = boatTiltAngle;
			water.Splash(transform.position.x, speed * boatSplashVelocity);
		}

		transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
	}

}
