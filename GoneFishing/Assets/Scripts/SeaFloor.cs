using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaFloor : MonoBehaviour {

	[SerializeField] private AnimationCurve groundCurve;
	[SerializeField] private float left = -15.0f;
	[SerializeField] private float width = 130.0f;
	[SerializeField] private float top = 0.0f;
	[SerializeField] private float bottom = -30.0f;
	[SerializeField] private float zPosition = 1.0f;
	[SerializeField] private int groundResolution = 3;
	[SerializeField] private GameObject groundMesh;

	[SerializeField] private Material lineMaterial;
	[SerializeField] private float lineWidth = 0.1f;

	private LineRenderer body;
	private float[] xPositions;
	private float[] yPositions;
	private GameObject[] meshes;

	
	// Use this for initialization
	void Start ()
	{
		SpawnGround();
	}

	private void SpawnGround()
	{
		int edgeCount = Mathf.RoundToInt(width) * groundResolution;
		int nodeCount = edgeCount + 1;

		xPositions = new float[nodeCount];
		yPositions = new float[nodeCount];
		meshes = new GameObject[edgeCount];


		body = gameObject.AddComponent<LineRenderer>();
		body.material = lineMaterial;
		body.material.renderQueue = 3000;
		body.positionCount = nodeCount;
		body.startWidth = lineWidth;

		for (int i = 0; i < nodeCount; i++)
		{
			float curveValue = groundCurve.Evaluate((float)i / (float)nodeCount);
			xPositions[i] = left + width * i / edgeCount;
			yPositions[i] = ((curveValue - 0.0f) / (1.0f - 0.0f)) * (top - bottom) + bottom;
			body.SetPosition(i, new Vector3(xPositions[i], yPositions[i], zPosition - 0.5f));
		}

		for(int i = 0; i < edgeCount; i++)
		{
			Vector3[] vertices = new Vector3[4];

			vertices[0] = new Vector3(xPositions[i], yPositions[i], zPosition);
			vertices[1] = new Vector3(xPositions[i + 1], yPositions[i + 1], zPosition);
			vertices[2] = new Vector3(xPositions[i], this.bottom - 10.0f, zPosition);
			vertices[3] = new Vector3(xPositions[i + 1], this.bottom - 10.0f, zPosition);

			Vector2[] uvCoord = new Vector2[4];
			uvCoord[0] = new Vector2(i + 0, 1);
			uvCoord[1] = new Vector2(i + 1, 1);
			uvCoord[2] = new Vector2(i + 0, 0);
			uvCoord[3] = new Vector2(i + 1, 0);

			int[] triangles = new int[6] { 0, 1, 3, 3, 2, 0 };

			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.uv = uvCoord;
			mesh.triangles = triangles;

			meshes[i] = GameObject.Instantiate(groundMesh, Vector3.zero, Quaternion.identity);
			meshes[i].GetComponent<MeshFilter>().mesh = mesh;
			meshes[i].transform.parent = gameObject.transform;
		}
	}

	public float SampleGround(float xPosition)
	{
		if (xPosition >= xPositions[0] && xPosition <= xPositions[xPositions.Length - 1])
		{
			xPosition -= xPositions[0];
			int index = Mathf.RoundToInt((xPositions.Length - 1) * (xPosition / (xPositions[xPositions.Length - 1] - xPositions[0])));
			return yPositions[index];
		}

		return 0.0f;
	}
}
