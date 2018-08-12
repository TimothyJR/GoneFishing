using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour {

	[SerializeField] private int currency = 0;
	[SerializeField] private TextMeshProUGUI currencyText;
	[SerializeField] private TextMeshProUGUI fishCaughtText;
	[SerializeField] private GameObject shop;
	[SerializeField] private GameObject buttonInputPrompt;
	[SerializeField] private BoatStats boatStats;
	[SerializeField] private FishHandler fishHandler;
    [SerializeField] private AudioSource shopsound;

	[Header("Sounds")]
    [SerializeField] private AudioClip openshopsound;
    [SerializeField] private AudioClip closeshopsound;
    [SerializeField] private AudioClip purchasesound;


	[Header("UI Components")]
    [SerializeField] private TextMeshProUGUI lineLengthText;
	[SerializeField] private TextMeshProUGUI baitRangeText;
	[SerializeField] private TextMeshProUGUI baitStrengthText;
	[SerializeField] private TextMeshProUGUI carryCapacityText;

	private int lineLengthLevel = 1;
	private int baitRangeLevel = 1;
	private int baitStrengthLevel = 1;
	private int carryCapacityLevel = 1;

	private int lineCost;
	private int rangeCost;
	private int strengthCost;
	private int carryCost;

	private bool checkForInput = false;

	

	private void Start()
	{
		FishHandler.FishCaught += AddToCurrency;
		lineCost = (int)(9.0f + Mathf.Pow(10.0f, lineLengthLevel / 3.0f));
		rangeCost = (int)(9.0f + Mathf.Pow(10.0f, baitRangeLevel / 3.0f));
		strengthCost = (int)(9.0f + Mathf.Pow(10.0f, baitStrengthLevel / 3.0f));
		carryCost = (int)(9.0f + Mathf.Pow(10.0f, carryCapacityLevel / 3.0f));
		baitRangeText.text = "$" + rangeCost;
		lineLengthText.text = "$" + lineCost;
		baitStrengthText.text = "$" + strengthCost;
		carryCapacityText.text = "$" + carryCost;

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
        shopsound.PlayOneShot(openshopsound, .5f);

        boatStats.gameObject.GetComponent<BoatController>().CanMove = false;
		currencyText.gameObject.SetActive(false);
		fishCaughtText.gameObject.SetActive(false);
		shop.SetActive(true);
		HideButtonPrompt();

	}

	public void CloseShop()
	{
        shopsound.PlayOneShot(closeshopsound, .5f);

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
		if (currency > rangeCost)
		{
            PlayPurchaseSound();

            boatStats.IncreaseBaitRangeLevel(baitRangeLevel);
			currency -= rangeCost;
			baitRangeLevel++;
			rangeCost = (int)(9.0f + Mathf.Pow(10.0f, baitRangeLevel / 3.0f));
			baitRangeText.text = "$" + rangeCost;
		}
	}

	public void BuyBaitStrength()
	{
		if (currency > strengthCost)
		{
            PlayPurchaseSound();

            boatStats.IncreaseBaitStrengthLevel(baitStrengthLevel);
			currency -= strengthCost;
			baitStrengthLevel++;
			strengthCost = (int)(9.0f + Mathf.Pow(10.0f, baitStrengthLevel / 3.0f));
			baitStrengthText.text = "$" + strengthCost;
		}
	}

	public void BuyLineLength()
	{
		if(currency > lineCost)
		{
            PlayPurchaseSound();

            boatStats.IncreaseLineLength(lineLengthLevel);
			currency -= lineCost;
			lineLengthLevel++;
			lineCost = (int)(9.0f + Mathf.Pow(10.0f, lineLengthLevel / 3.0f));
			lineLengthText.text = "$" + lineCost;
		}
	}

	public void BuyCarryCapacity()
	{
		if (currency > carryCost)
		{
            PlayPurchaseSound();

            boatStats.IncreaseCarryAmount(carryCapacityLevel);
			currency -= carryCost;
			carryCapacityLevel++;
			carryCost = (int)(9.0f + Mathf.Pow(10.0f, carryCapacityLevel / 3.0f));
			carryCapacityText.text = "$" + carryCost;
		}
	}

    private void PlayPurchaseSound()
    {
        shopsound.PlayOneShot(purchasesound, .5f);
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
