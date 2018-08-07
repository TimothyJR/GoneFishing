using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

	[SerializeField] private float windSpeed = 1.0f;
	[SerializeField] private AnimationCurve x;
	[SerializeField] private AnimationCurve y;
	[SerializeField] private float timeToLoop = 1.5f;
	[SerializeField] private float loopScale = 1.0f;
	[SerializeField] private float avgTimeToNextLoop = 3.0f;
	[SerializeField] private float avgTimeToNextVariation = 0.5f;
	[SerializeField] private GameObject gameCameraObject;

	private Camera gameCamera;
	private TrailRenderer trailRenderer;

	private float timeBetweenLoops;
	private float timer = 0.0f;
	private bool looping = false;

	private void Start()
	{
		timeBetweenLoops = avgTimeToNextLoop + Random.Range(-avgTimeToNextVariation, avgTimeToNextVariation);
		gameCamera = gameCameraObject.GetComponent<Camera>();
		trailRenderer = this.GetComponent<TrailRenderer>();
	}


	private void Update ()
	{

		float speedPerFrame = windSpeed * Time.deltaTime;
		timer += Time.deltaTime;

		if (!looping)
		{
			transform.position = new Vector3(transform.position.x + speedPerFrame, transform.position.y, transform.position.z);

			if (timer > timeBetweenLoops)
			{
				looping = true;
				timer = 0.0f;
			}
			
		}
		else
		{
			transform.position = new Vector3(transform.position.x + speedPerFrame * x.Evaluate(timer / timeToLoop) * loopScale, transform.position.y + speedPerFrame * y.Evaluate(timer / timeToLoop) * loopScale, transform.position.z);
			
			if(timer > timeToLoop)
			{
				timer = 0.0f;
				looping = false;
				timeBetweenLoops = avgTimeToNextLoop + Random.Range(-avgTimeToNextVariation, avgTimeToNextVariation);
			}
		}

		if (transform.position.x > gameCameraObject.transform.position.x + gameCamera.orthographicSize * 2 + trailRenderer.time * 2)
		{
			Reset();
		}
		
	}

	private void Reset()
	{
		float xPosition = gameCameraObject.transform.position.x - gameCamera.orthographicSize * 2;
		float yPosition = Random.Range(0.4f, 2.0f);
		transform.position = new Vector3(xPosition, yPosition, transform.position.z);
		timer = 0;
		looping = false;
		trailRenderer.Clear();
		int numberOfChildren = transform.childCount;
		for(int i = 0; i < numberOfChildren; i++)
		{
			transform.GetChild(i).GetComponent<TrailRenderer>().Clear();
		}

	}
}
