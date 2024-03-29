﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishHandler : MonoBehaviour
{
	[SerializeField] private GameObject[] fishList;
	[SerializeField] private GameObject boat;
	[SerializeField] private TextMeshProUGUI fishCaughtText;
	[SerializeField] private SeaFloor seaFloor;
	[SerializeField] private float fishMinScale = 0.6f;
	[SerializeField] private float fishMaxScale = 1.2f;
	[SerializeField] private AudioClip fishysound;

	private BoatStats boatStats;
	private ZoneHandler zoneHandler;
	private FishingLine line;
	private AudioSource boataudio;
	private int amountCaught;
	private bool maxCaptured = false;
	List<GameObject> spawnedFish;


	public bool MaxCaptured { get { return maxCaptured; } }

	public delegate void OnFishCaught(int FishWorth);
	public static event OnFishCaught FishCaught;


	private void Start()
	{
		boataudio = boat.GetComponent<AudioSource>();

		spawnedFish = new List<GameObject>();
		line = boat.GetComponent<BoatLine>().Line.GetComponent<FishingLine>();
		boatStats = boat.GetComponent<BoatStats>();
		zoneHandler = gameObject.GetComponent<ZoneHandler>();
		ZoneHandler.SectionChanged += SectionChange;
		fishCaughtText.text = "Fish Caught 0/" + boatStats.CarryAmount;
		SectionChange();
	}

	private void Update()
	{
		if(spawnedFish.Count < zoneHandler.CurrentMaxFish)
		{
			if(Random.Range(0,100) < 1)
			{
				int fishIndex = Random.Range(0, fishList.Length);

				float x = 0.0f;
				if(zoneHandler.CurrentZone != 0)
				{
					float side = Random.Range(0, 1);
					if(side > 0)
					{
						x = zoneHandler.ZoneBorderRight + 3.0f;
					}
					else
					{
						x = zoneHandler.ZoneBorderLeft - 3.0f;
					}
				}
				else
				{
					x = zoneHandler.ZoneBorderRight + 3.0f;
				}

				float y = Random.Range(-1.5f, seaFloor.SampleGround(x)) + 1.0f;
				SpawnFish(fishList[fishIndex], new Vector3(x, y));
			}
		}
	}

	private void FixedUpdate()
	{
		for(int i = 0; i < spawnedFish.Count; i++)
		{
			spawnedFish[i].GetComponent<FishBehaviors>().FishUpdate(Time.fixedDeltaTime, zoneHandler.ZoneBorderLeft, zoneHandler.ZoneBorderRight);
		}
	}

	private void SpawnFish(GameObject fish, Vector3 position)
	{
		GameObject instantiatedFish = GameObject.Instantiate(fish);
		instantiatedFish.transform.position = position;
		instantiatedFish.GetComponent<FishBehaviors>().FishStart(boat.GetComponent<BoatStats>());
		instantiatedFish.GetComponent<FishBehaviors>().Handler = this;
		instantiatedFish.transform.GetChild(0).transform.localScale = new Vector3(Random.Range(fishMinScale, fishMaxScale), Random.Range(fishMinScale, fishMaxScale), Random.Range(fishMinScale, fishMaxScale));
		spawnedFish.Add(instantiatedFish);
	}

	public void CheckFishCaughtOnLine(GameObject fish)
	{
		if(amountCaught < boatStats.CarryAmount)
		{
			if (line.EndJoint != null)
			{
				if (Vector3.Distance(line.EndJoint.transform.position, fish.transform.position) < 0.5f)
				{
					if (FishCaught != null)
					{
						boataudio.PlayOneShot(fishysound, .10f);

						amountCaught += 1;
						fishCaughtText.text = fishCaughtText.text = "Fish Caught " + amountCaught + "/" + boatStats.CarryAmount;
						FishCaught(fish.GetComponent<FishBehaviors>().FishWorth);
					}
					spawnedFish.Remove(fish);
					Destroy(fish);
				}
			}
		}
		else
		{
			maxCaptured = true;
		}
	}

	public Vector3 LineEndPosition()
	{
		if(line.EndJoint != null)
		{
			return line.EndJoint.transform.position;
		}
		return Vector3.zero;
	}

	private void SectionChange()
	{
		if(zoneHandler.CurrentFishList != null)
		{
			fishList = zoneHandler.CurrentFishList;
		}
		
		for(int i = spawnedFish.Count - 1; i >= 0; i--)
		{
			Destroy(spawnedFish[i]);
			spawnedFish.RemoveAt(i);
		}
		
	}

	public void ResetAmountCaught()
	{
		amountCaught = 0;
		maxCaptured = false;
		fishCaughtText.text = "Fish Caught 0/" + boatStats.CarryAmount;
	}

	public float SampleGround(float x)
	{
		return seaFloor.SampleGround(x);
	}
}