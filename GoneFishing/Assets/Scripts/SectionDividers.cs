using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SectionDividers
{
	[SerializeField] private GameObject dividerObject;
	[SerializeField] private string sectionName;
	[SerializeField] private int maxFish = 30;
	[SerializeField] private GameObject[] sectionFish;

	public GameObject DividerObject { get { return dividerObject; } }
	public string SectionName { get { return sectionName; } }
	public GameObject[] SectionFish { get { return sectionFish; } }
	public int MaxFish { get { return maxFish; } }
}
