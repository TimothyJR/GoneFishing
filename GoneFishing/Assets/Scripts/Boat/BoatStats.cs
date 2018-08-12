using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatStats : MonoBehaviour {

	private const float BASE_BAIT_RANGE = 1.0f;
	private const float BASE_BAIT_STRENGTH = 1.0f;
	private const int BASE_LINE_LENGTH = 25;
	private const int BASE_CARRY_AMOUNT = 10;

	private float baitRange = 1.0f;
	private float baitStrength = 1.0f;
	private int lineLength = 25;
	private int carryAmount = 20;

	public float BaitRange { get { return baitRange; } }
	public float BaitStrength { get { return baitStrength; } }
	public float LineLength { get { return lineLength; } }
	public float CarryAmount { get { return carryAmount; } }



	public void IncreaseBaitRangeLevel(int level)
	{
		baitRange = (level * 0.1f) + BASE_BAIT_RANGE;
	}

	public void IncreaseBaitStrengthLevel(int level)
	{
		baitStrength = (level * 0.1f) + BASE_BAIT_STRENGTH;
	}

	public void IncreaseLineLength(int level)
	{
		lineLength = BASE_LINE_LENGTH + (level * 2);
	}

	public void IncreaseCarryAmount(int level)
	{
		carryAmount = BASE_CARRY_AMOUNT + (level * 5);
	}
}
