using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Water))]
public class LightShaftSpawner : MonoBehaviour {

	[SerializeField] private GameObject[] lightShafts;
	[SerializeField] private float averageDistanceBetween = 3.0f;
	[SerializeField] private float distanceVariation = 1.5f;


	// Use this for initialization
	void Start () {

		Water water = GetComponent<Water>();
		float startingX = water.Left;
		float endingX = water.Width;
		float currentX = startingX;

		while(currentX < endingX)
		{
			int shaftToSpawn = Random.Range(0, lightShafts.Length);
			float xDifference = averageDistanceBetween + Random.Range(-distanceVariation, distanceVariation);
			currentX += xDifference;
			GameObject lightShaft = GameObject.Instantiate(lightShafts[shaftToSpawn], new Vector3(currentX, 0.0f, 1.3f), Quaternion.identity);
			lightShaft.transform.parent = transform;
		}
		
	}
	
}
