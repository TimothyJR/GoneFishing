using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviors : MonoBehaviour
{
	Vector3 acceleration;
	Vector3 velocity;
	float wanderCounter;
	Vector3 wanderPoint;
	BoatStats boatStats;
	[SerializeField] private float maxSpeed = 2.0f;
	[SerializeField] private float minDepthLevel = -1.0f;
	[SerializeField] private float preferedDepethLevel = -5.0f;
	[SerializeField] private float wanderXRange = 20.0f;
	[SerializeField] private float wanderYRange = 5.0f;

	[SerializeField] private int fishWorth = 5;

	[Header("Force Weights")]
	[SerializeField] private float wanderWeight = 0.9f;
	[SerializeField] private float preferedDepthWeight = 0.3f;
	[SerializeField] private float baitWeight = 0.1f;
	[SerializeField] private float zoneWeight = 4.0f;
	[SerializeField] private float minDepthWeight = 1.0f;

	private FishHandler handler;

	public FishHandler Handler
	{
		set { handler = value; }
	}

	public int FishWorth
	{ get { return fishWorth; } }

	public void FishStart(BoatStats stats)
	{
		velocity = transform.forward;
		boatStats = stats;
	}

	public void FishUpdate(float time, float zoneLeft, float zoneRight)
	{
		CalculateSteeringForces(time, zoneLeft, zoneRight);
		acceleration.z = 0.0f;
		velocity += acceleration * time;
		velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
		velocity.z = 0.0f;
		if(velocity != Vector3.zero)
		{
			transform.forward = velocity.normalized;
		}

		transform.position += velocity * time;

		handler.CheckFishCaughtOnLine(gameObject);
	}

	private void CalculateSteeringForces(float time, float zoneLeft, float zoneRight)
	{
		Vector3 applicationForce = Vector3.zero;

		// Wander the fish around
		applicationForce += Wander(time) * wanderWeight;

		// Keep fishes towards their prefered depth
		applicationForce += Seek(new Vector3(transform.position.x, preferedDepethLevel, 0)) * preferedDepthWeight * ((transform.position.y - preferedDepethLevel) / 4);

		if(transform.position.y > minDepthLevel)
		{
			applicationForce += Seek(new Vector3(transform.position.x, minDepthLevel - 1)) * minDepthWeight;
		}

		// Keep in zones
		if(transform.position.x > zoneRight || transform.position.x < zoneLeft)
		{
			applicationForce += Seek(new Vector3(Random.Range(zoneLeft, zoneRight), transform.position.y, 0.0f)) * zoneWeight;
		}

		// Apply force for bait if within range
		if(!handler.MaxCaptured)
		{
			if (handler.LineEndPosition() != Vector3.zero)
			{
				if (Vector3.Distance(transform.position, handler.LineEndPosition()) < boatStats.BaitRange)
				{
					applicationForce += Seek(handler.LineEndPosition()) * baitWeight * boatStats.BaitStrength;
				}
			}
		}
		

		acceleration += applicationForce;
	}

	// Return a vector pointing towards a random point below the water surface
	private Vector3 Wander(float time)
	{
		Vector3 center = transform.position;

		if(wanderCounter >= 2)
		{
			wanderCounter = 0;
			float x = center.x + Random.Range(-wanderXRange, wanderXRange);
			float groundPosition = handler.SampleGround(x);
			float y;

			if (center.y + wanderYRange > 0.0f && center.y - wanderYRange < groundPosition)
			{
				y = center.y + Random.Range(groundPosition - center.y, Mathf.Abs(center.y));
			}
			else if (center.y - wanderYRange < groundPosition)
			{
				y = center.y + Random.Range(groundPosition - center.y, wanderYRange);
			}
			else if(center.y + wanderYRange > 0.0f)
			{
				y = center.y + Random.Range(-wanderYRange, Mathf.Abs(center.y));
			}
			else
			{
				y = center.y + Random.Range(-wanderYRange, wanderYRange);
			}

			wanderPoint = new Vector3(x, y, 0);
		}

		wanderCounter += time;
		return Seek(wanderPoint);
	}

	// Return a vector pointing towards the input position
	private Vector3 Seek(Vector3 seekPosition)
	{
		Vector3 deltaVelocity;
		deltaVelocity = seekPosition - transform.position;
		deltaVelocity = deltaVelocity.normalized * maxSpeed;
		deltaVelocity -= velocity;
		return deltaVelocity;
	}
}
