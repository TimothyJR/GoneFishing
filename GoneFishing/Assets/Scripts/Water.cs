using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
	private float[] xPositions;
	private float[] yPositions;
	private float[] velocities;
	private float[] accelerations;
	private LineRenderer body;


	private GameObject[] meshObjects;


	private const float springConstant = 0.02f;
	private const float damping = 0.04f;
	private const float spread = 0.05f;
	[SerializeField] private Material lineMaterial;
	[SerializeField] private float lineWidth = 0.1f;
	[SerializeField] private GameObject waterMesh;
	[SerializeField] private int waterResolution = 5;
	[SerializeField] private float left = -15.0f;
	[SerializeField] private float width = 130.0f;
	[SerializeField] private float top = 0.0f;
	[SerializeField] private float bottom = -30.0f;
	[SerializeField] private float zPosition = -1.0f;


	void Start ()
	{
		SpawnWater();	
	}

	
	private void SpawnWater()
	{
		int edgeCount = Mathf.RoundToInt(width) * waterResolution;
		int nodeCount = edgeCount + 1;

		body = gameObject.AddComponent<LineRenderer>();
		body.material = lineMaterial;
		body.material.renderQueue = 3000;
		body.positionCount = nodeCount;
		body.startWidth = lineWidth;

		xPositions = new float[nodeCount];
		yPositions = new float[nodeCount];
		velocities = new float[nodeCount];
		accelerations = new float[nodeCount];

		meshObjects = new GameObject[edgeCount];


		for (int i = 0; i < nodeCount; i++)
		{
			xPositions[i] = left + width * i / edgeCount;
			yPositions[i] = top;
			accelerations[i] = 0;
			velocities[i] = 0;
			body.SetPosition(i, new Vector3(xPositions[i], yPositions[i], zPosition - 0.5f));
		}

		for (int i = 0; i < edgeCount; i++)
		{
			Mesh meshes = new Mesh();

			Vector3[] vertices = new Vector3[4];
			vertices[0] = new Vector3(xPositions[i], yPositions[i], zPosition);
			vertices[1] = new Vector3(xPositions[i + 1], yPositions[i + 1], zPosition);
			vertices[2] = new Vector3(xPositions[i], this.bottom, zPosition);
			vertices[3] = new Vector3(xPositions[i + 1], this.bottom, zPosition);

			Vector2[] uvCoord = new Vector2[4];
			uvCoord[0] = new Vector2(i+0, 1);
			uvCoord[1] = new Vector2(i+1, 1);
			uvCoord[2] = new Vector2(i+0, 0);
			uvCoord[3] = new Vector2(i+1, 0);

			int[] triangles = new int[6] { 0, 1, 3, 3, 2, 0 };

			meshes.vertices = vertices;
			meshes.uv = uvCoord;
			meshes.triangles = triangles;

			meshObjects[i] = GameObject.Instantiate(waterMesh, Vector3.zero, Quaternion.identity);
			meshObjects[i].GetComponent<MeshFilter>().mesh = meshes;
			meshObjects[i].transform.parent = gameObject.transform;

		}

	}

	void FixedUpdate ()
	{
		for (int i = 0; i < xPositions.Length; i++)
		{
			float force = springConstant * (yPositions[i] - top) + velocities[i] * damping;
			accelerations[i] = -force;
			yPositions[i] += velocities[i];
			velocities[i] += accelerations[i];
			body.SetPosition(i, new Vector3(xPositions[i], yPositions[i], zPosition - 0.5f));
		}

		float[] leftDeltas = new float[xPositions.Length];
		float[] rightDeltas = new float[xPositions.Length];

		for (int j = 0; j < 8; j++)
		{
			for (int i = 0; i < xPositions.Length; i++)
			{
				if (i > 0)
				{
					leftDeltas[i] = spread * (yPositions[i] - yPositions[i - 1]);
					velocities[i - 1] += leftDeltas[i];
				}
				if (i < xPositions.Length - 1)
				{
					rightDeltas[i] = spread * (yPositions[i] - yPositions[i + 1]);
					velocities[i + 1] += rightDeltas[i];
				}
			}
		}

		for (int i = 0; i < xPositions.Length; i++)
		{
			if (i < 0)
			{
				yPositions[i - 1] += leftDeltas[i];
			}
			if (i < xPositions.Length - 1)
			{
				yPositions[i + 1] += rightDeltas[i];
			}
		}
		UpdateMeshes();
	}


	private void UpdateMeshes()
	{
		for(int i = 0; i < meshObjects.Length; i++)
		{
			Vector3[] vertices = new Vector3[4];
			vertices[0] = new Vector3(xPositions[i], yPositions[i], zPosition);
			vertices[1] = new Vector3(xPositions[i + 1], yPositions[i + 1], zPosition);
			vertices[2] = new Vector3(xPositions[i], bottom, zPosition);
			vertices[3] = new Vector3(xPositions[i + 1], bottom, zPosition);

			meshObjects[i].GetComponent<MeshFilter>().mesh.vertices = vertices;
		}
	}

	public void Splash(float xPosition, float velocity)
	{
		if(xPosition >= xPositions[0] && xPosition <= xPositions[xPositions.Length - 1])
		{
			xPosition -= xPositions[0];
			int index = Mathf.RoundToInt((xPositions.Length - 1) * (xPosition / (xPositions[xPositions.Length - 1] - xPositions[0])));
			velocities[index] = velocity;

		}
	}

	public Vector3 VertexPositionAroundX(float xPosition)
	{
		if (xPosition >= xPositions[0] && xPosition <= xPositions[xPositions.Length - 1])
		{
			xPosition -= xPositions[0];
			int index = Mathf.RoundToInt((xPositions.Length - 1) * (xPosition / (xPositions[xPositions.Length - 1] - xPositions[0])));

			if(index < 1)
			{
				return new Vector3(yPositions[index], yPositions[index], yPositions[index + 1]);
			}
			else if(index > yPositions.Length - 2)
			{
				return new Vector3(yPositions[index - 1], yPositions[index], yPositions[index]);
			}

			return new Vector3(yPositions[index - 1], yPositions[index], yPositions[index + 1]);
		}

		return Vector3.zero;
	}


}
