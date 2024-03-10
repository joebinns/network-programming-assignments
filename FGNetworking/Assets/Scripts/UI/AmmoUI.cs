using System;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
	[SerializeField] Image loadingBarImage;
	[SerializeField] Transform backdrop;
	[SerializeField] Ammo ammo;
	[SerializeField, Range(-1f, 0f)] private float _verticalOffset = -0.8f;

	void Start()
	{
		ammo.currentAmmo.OnValueChanged += UpdateUI;
	}

	private void UpdateUI(int previousValue, int newValue)
	{
		loadingBarImage.fillAmount = (float)newValue / Ammo.MAX_AMMO;
	}

	private void Update()
	{
		transform.position = transform.parent.position + _verticalOffset * Vector3.up;
		transform.rotation = Quaternion.identity;

		backdrop.position = backdrop.parent.position + _verticalOffset * Vector3.up;
		backdrop.rotation = Quaternion.identity;
	}
}
