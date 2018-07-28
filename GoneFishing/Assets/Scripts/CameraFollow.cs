using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	[SerializeField] private GameObject trackingTarget;
	[SerializeField] private ZoneHandler zoneHandler;
	private Camera boatCamera;
	private float yPosition;
	private float desiredScale = 5.0f;
	private float xLimitLeft;
	private float xLimitRight;

	private void Start()
	{
		boatCamera = GetComponent<Camera>();
		ZoneHandler.SectionChanged += ZoneChange;
		yPosition = -(boatCamera.orthographicSize / 3);
		desiredScale = (zoneHandler.CurrentZone + 1) * 4;
		CalculateCameraLimits();
		this.transform.position = new Vector3(xLimitLeft, yPosition, -5);
	
	}

	private void FixedUpdate()
	{
		Vector3 desiredPosition; 
		if(trackingTarget.transform.position.x < xLimitLeft)
		{
			desiredPosition = new Vector3(xLimitLeft, yPosition, -5);
		}
		else if(trackingTarget.transform.position.x > xLimitRight)
		{
			desiredPosition = new Vector3(xLimitRight, yPosition, -5);
		}
		else
		{
			desiredPosition = new Vector3(trackingTarget.transform.position.x, yPosition, -5);
		}

		transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.fixedDeltaTime);
		boatCamera.orthographicSize = Mathf.Lerp(boatCamera.orthographicSize, desiredScale, Time.fixedDeltaTime);
	}

	private void ZoneChange()
	{
		desiredScale = (zoneHandler.CurrentZone + 1) * 4;
		yPosition = -(boatCamera.orthographicSize / 3);
		CalculateCameraLimits();
		
	}

	private void CalculateCameraLimits()
	{
		xLimitLeft = zoneHandler.ZoneBorderLeft + (desiredScale * 16 / 9) - 2;
		xLimitRight = zoneHandler.ZoneBorderRight - (desiredScale * 16 / 9) + 2;

		if (xLimitLeft > xLimitRight)
		{
			xLimitLeft = (xLimitLeft + xLimitRight) / 2;
			xLimitRight = xLimitLeft;
		}
	}
}
