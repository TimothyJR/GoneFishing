using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This script is used to avoid physics issues with the joints
 * If the line's position is not controlled through code, the joints will not work properly when the boat direction is changed
*/
public class BoatLine : MonoBehaviour {

	[SerializeField] private GameObject line;
	private GameObject lineInstance;

	public GameObject Line
	{
		get { return lineInstance; }
	}

	private void Start ()
	{
		lineInstance = GameObject.Instantiate(line);
		lineInstance.transform.position = transform.position;
		lineInstance.GetComponent<FishingLine>().boatStatistics = this.GetComponent<BoatStats>();
	}
	
	private void FixedUpdate ()
	{
		float direction = -Mathf.Sign(transform.rotation.y);

		lineInstance.transform.position = new Vector3(transform.position.x + direction, transform.position.y, transform.position.z);
	}
}
