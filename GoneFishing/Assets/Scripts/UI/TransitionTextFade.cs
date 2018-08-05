using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionTextFade : MonoBehaviour {

	private TextMeshProUGUI text;
	private float timer = 0.0f;
	private int fadeState = 0;
	Color faceColor;
	Color outlineColor;

	[SerializeField] private float fadeInTime = 0.5f;
	[SerializeField] private float inBetweenTime = 1.0f;
	[SerializeField] private float fadeOutTime = 0.5f;

	private void Start()
	{
		text = this.GetComponent<TextMeshProUGUI>();
		faceColor = text.fontMaterial.GetColor(ShaderUtilities.ID_FaceColor);
		outlineColor = text.fontMaterial.GetColor(ShaderUtilities.ID_OutlineColor);
		this.gameObject.SetActive(false);
	}

	private void Update ()
	{
		float alpha;
		switch(fadeState)
		{
			case 0:
				timer += Time.deltaTime;
				alpha = Mathf.Lerp(0.0f, 1.0f, timer / fadeInTime);
				faceColor.a = alpha;
				outlineColor.a = alpha;
				text.fontMaterial.SetColor(ShaderUtilities.ID_FaceColor, faceColor);
				text.fontMaterial.SetColor(ShaderUtilities.ID_OutlineColor, outlineColor);

				if (timer > fadeInTime)
				{
					faceColor.a = 1.0f;
					outlineColor.a = 1.0f;
					timer = 0;
					fadeState++;
				}

				break;
			case 1:
				timer += Time.deltaTime;
				if(timer > inBetweenTime)
				{
					timer = 0;
					fadeState++;
				}

				break;
			case 2:
				timer += Time.deltaTime;
				alpha = Mathf.Lerp(1.0f, 0.0f, timer / fadeOutTime);
				faceColor.a = alpha;
				outlineColor.a = alpha;
				text.fontMaterial.SetColor(ShaderUtilities.ID_FaceColor, faceColor);
				text.fontMaterial.SetColor(ShaderUtilities.ID_OutlineColor, outlineColor);

				if (timer > fadeOutTime)
				{
					gameObject.SetActive(false);
				}

				break;
		}
	}

	public void IncrementZone(ZoneHandler handler)
	{
		faceColor.a = 0.0f;
		outlineColor.a = 0.0f;
		text.fontMaterial.SetColor(ShaderUtilities.ID_FaceColor, faceColor);
		text.fontMaterial.SetColor(ShaderUtilities.ID_OutlineColor, outlineColor);
		timer = 0.0f;
		fadeState = 0;
		text.text = "Welcome to " + handler.CurrentZoneName;
	}

	public void DecrementZone(ZoneHandler handler)
	{
		faceColor.a = 0.0f;
		outlineColor.a = 0.0f;
		text.fontMaterial.SetColor(ShaderUtilities.ID_FaceColor, faceColor);
		text.fontMaterial.SetColor(ShaderUtilities.ID_OutlineColor, outlineColor);
		timer = 0.0f;
		fadeState = 0;
		text.text = "Returning to " + handler.CurrentZoneName;
	}
}
