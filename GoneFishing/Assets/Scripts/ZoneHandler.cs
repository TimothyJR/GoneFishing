﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneHandler : MonoBehaviour {

	[SerializeField] private GameObject boat;
	[SerializeField] private SectionDividers[] sectionDividers;
	[SerializeField] private float finalZoneLength = 30.0f;
	[SerializeField] private TransitionTextFade zoneTransitionText;
	private int currentZone = 0;
	private float zoneBorderLeft = 0;
	private float zoneBorderRight = 0;

	public delegate void SectionChange();
	public static event SectionChange SectionChanged;

	public int CurrentZone
	{ get { return currentZone; } }

	public float ZoneBorderLeft
	{ get { return zoneBorderLeft; } }

	public float ZoneBorderRight
	{ get { return zoneBorderRight; } }

	public GameObject[] CurrentFishList
	{ get { return sectionDividers[currentZone].SectionFish; } }

	public int CurrentMaxFish
	{ get { return sectionDividers[currentZone].MaxFish; } }

	public string CurrentZoneName
	{ get { return sectionDividers[currentZone].SectionName; } }

	private void Start()
	{
		if(sectionDividers.Length > 1)
		{
			zoneBorderRight = sectionDividers[1].DividerObject.transform.position.x;
		}
	}

	private void Update()
	{
		if(sectionDividers.Length > 1)
		{
			if (currentZone == 0) 
			{
				if(boat.transform.position.x > sectionDividers[1].DividerObject.transform.position.x)
				{
					IncrementZone();
				}	
			}
			else if (currentZone == sectionDividers.Length - 1)
			{
				if (boat.transform.position.x < sectionDividers[sectionDividers.Length - 1].DividerObject.transform.position.x)
				{
					DecrementZone();
				}
			}
			else
			{
				if (boat.transform.position.x > sectionDividers[currentZone + 1].DividerObject.transform.position.x)
				{
					IncrementZone();
				}
				else if(boat.transform.position.x < sectionDividers[currentZone].DividerObject.transform.position.x)
				{
					DecrementZone();
				}
			}
		}
	}

	public void IncrementZone()
	{
		currentZone++;
		zoneTransitionText.gameObject.SetActive(true);
		zoneTransitionText.IncrementZone(this);
		zoneBorderLeft = sectionDividers[currentZone].DividerObject.transform.position.x;

		if (currentZone < sectionDividers.Length - 1)
		{
			zoneBorderRight = sectionDividers[currentZone + 1].DividerObject.transform.position.x;

			if (SectionChanged != null)
			{
				SectionChanged();
			}
		}
		else
		{
			zoneBorderRight = sectionDividers[currentZone].DividerObject.transform.position.x + finalZoneLength;
			
			if (SectionChanged != null)
			{
				SectionChanged();
			}
		}
	}

	public void DecrementZone()
	{
		zoneBorderRight = sectionDividers[currentZone].DividerObject.transform.position.x;
		currentZone--;
		zoneTransitionText.gameObject.SetActive(true);
		zoneTransitionText.DecrementZone(this);
		if (currentZone == 0)
		{
			zoneBorderLeft = 0;
			
			if (SectionChanged != null)
			{
				SectionChanged();
			}
		}
		else
		{
			zoneBorderLeft = sectionDividers[currentZone].DividerObject.transform.position.x;

			if (SectionChanged != null)
			{
				SectionChanged();
			}
		}
		
	}

}


