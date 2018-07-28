using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class FishingLine : MonoBehaviour {

	[SerializeField] private float jointLength = 0.1f;
	[SerializeField] private GameObject joint;

	private BoatStats boatStats;
	private List<GameObject> joints;
	private GameObject endJoint;
	private LineRenderer lineRenderer;

	public BoatStats boatStatistics
	{ set { boatStats = value; } }
		

	public GameObject EndJoint
	{
		get { return endJoint; }
	}

	// Use this for initialization
	private void Start ()
	{
		joints = new List<GameObject>();
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	private void FixedUpdate ()
	{
		if(Input.GetKey(KeyCode.S))
		{
			if(joints.Count < boatStats.LineLength)
			{
				AddJoints();
			}
		}
		if(Input.GetKey(KeyCode.W))
		{
			if (joints.Count > 0)
			{
				RemoveJoints();
			}
		}

		UpdateLineRenderer();

	}


	private void AddJoints()
	{
		GameObject newJoint  = GameObject.Instantiate(joint);


		if (joints.Count > 0)
		{
			newJoint.transform.position = new Vector3(endJoint.transform.position.x, endJoint.transform.position.y - jointLength, 0);
			newJoint.GetComponent<ConfigurableJoint>().connectedBody = endJoint.GetComponent<Rigidbody>();
		}
		else
		{
			newJoint.transform.position = transform.position;
			newJoint.GetComponent<ConfigurableJoint>().connectedBody = GetComponent<Rigidbody>();
		}

		endJoint = newJoint;
		joints.Add(newJoint);


	}

	private void RemoveJoints()
	{
		Destroy(joints[joints.Count - 1]);
		joints.RemoveAt(joints.Count - 1);
		if(joints.Count >=1)
		{
			endJoint = joints[joints.Count - 1];
		}
		else
		{
			endJoint = null;
		}
		
	}

	private void UpdateLineRenderer()
	{
		lineRenderer.positionCount = joints.Count;
		for(int i = 0; i < joints.Count; i++)
		{
			if(i == 0 || i == joints.Count - 1)
			{
				lineRenderer.SetPosition(i, joints[i].transform.position);
			}
			else 
			{
				Vector3 linePosition = joints[i - 1].transform.position + joints[i].transform.position + joints[i + 1].transform.position;
				linePosition /= 3;
				lineRenderer.SetPosition(i, linePosition);
			}

		}

	}
}
