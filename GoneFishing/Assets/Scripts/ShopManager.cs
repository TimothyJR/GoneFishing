using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI currencyText;
	[SerializeField] private TextMeshProUGUI fishCaughtText;
	[SerializeField] private GameObject shop;
	[SerializeField] private GameObject buttonInputPrompt;
	[SerializeField] private BoatStats boatStats;
	[SerializeField] private FishHandler fishHandler;

	[SerializeField] private TextMeshProUGUI lineLengthText;
	[SerializeField] private TextMeshProUGUI baitRangeText;
	[SerializeField] private TextMeshProUGUI baitStrengthText;
	[SerializeField] private TextMeshProUGUI carryCapacityText;

	private int lineLengthLevel = 1;
	private int baitRangeLevel = 1;
	private int baitStrengthLevel = 1;
	private int carryCapacityLevel = 1;

	private bool checkForInput = false;
	[SerializeField] private int currency = 0;

	private void Start()
	{
		FishHandler.FishCaught += AddToCurrency;
	}

	private void Update()
	{
		if (checkForInput)
		{
			if (Input.GetKey("1"))
			{
				OpenShop();
			}
		}
	}

	private void AddToCurrency(int amount)
	{
		currency += amount;
		UpdateCurrencyText();
	}

	private void OpenShop()
	{
		boatStats.gameObject.GetComponent<BoatController>().CanMove = false;
		currencyText.gameObject.SetActive(false);
		fishCaughtText.gameObject.SetActive(false);
		shop.SetActive(true);
		HideButtonPrompt();

	}

	public void CloseShop()
	{
		boatStats.gameObject.GetComponent<BoatController>().CanMove = true;
		currencyText.gameObject.SetActive(true);
		fishCaughtText.gameObject.SetActive(true);
		shop.SetActive(false);
		UpdateCurrencyText();
		ShowButtonPrompt();
	}

	private void UpdateCurrencyText()
	{
		currencyText.text = "$" + currency;
	}

	public void BuyBaitRange()
	{
		int rangeCost = (int)(9 + Mathf.Pow(10, baitRangeLevel / 10));
		if (currency > rangeCost)
		{
			boatStats.IncreaseBaitRangeLevel(baitRangeLevel);
			currency -= rangeCost;
			baitRangeLevel++;
			rangeCost = (int)(9 + Mathf.Pow(10, baitRangeLevel / 10));
			baitRangeText.text = "$" + rangeCost;
		}
	}

	public void BuyBaitStrength()
	{
		int strengthCost = (int)(9 + Mathf.Pow(10, baitStrengthLevel / 10));
		if (currency > strengthCost)
		{
			boatStats.IncreaseBaitStrengthLevel(baitStrengthLevel);
			currency -= strengthCost;
			baitStrengthLevel++;
			strengthCost = (int)(9 + Mathf.Pow(10, baitStrengthLevel / 10));
			baitStrengthText.text = "$" + baitStrengthLevel;
		}
	}

	public void BuyLineLength()
	{
		int lineCost = (int)(9 + Mathf.Pow(10, lineLengthLevel / 10));
		if(currency > lineCost)
		{
			boatStats.IncreaseLineLength(lineLengthLevel);
			currency -= lineCost;
			lineLengthLevel++;
			lineCost = (int)(9 + Mathf.Pow(10, lineLengthLevel / 10));
			lineLengthText.text = "$" + lineCost;
		}
	}

	public void BuyCarryCapacity()
	{
		int carryCost = (int)(9 + Mathf.Pow(10, carryCapacityLevel / 10));
		if (currency > carryCost)
		{
			boatStats.IncreaseCarryAmount(carryCapacityLevel);
			currency -= carryCost;
			carryCapacityLevel++;
			carryCost = (int)(9 + Mathf.Pow(10, carryCapacityLevel / 10));
			carryCapacityText.text = "$" + carryCost;
		}
	}


	private void ShowButtonPrompt()
	{
		buttonInputPrompt.SetActive(true);
		
		checkForInput = true;
	}

	private void HideButtonPrompt()
	{
		buttonInputPrompt.SetActive(false);
		checkForInput = false;
	}
	private void OnTriggerEnter(Collider other)
	{
		fishHandler.ResetAmountCaught();
		ShowButtonPrompt();
	}

	private void OnTriggerExit(Collider other)
	{
		HideButtonPrompt();
	}

	

}
