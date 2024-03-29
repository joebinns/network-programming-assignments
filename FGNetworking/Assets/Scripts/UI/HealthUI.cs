using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
	[SerializeField] Image loadingBarImage;
	[SerializeField] Transform backdrop;
	[SerializeField] Health health;
	[SerializeField, Range(-1f, 0f)] private float _verticalOffset = -0.6f;

	void Start()
	{
		health.currentHealth.OnValueChanged += UpdateUI;
	}

	private void UpdateUI(int previousValue, int newValue)
	{
		loadingBarImage.fillAmount = (float)newValue / Health.MAX_HEALTH;
	}

	private void Update()
	{
		transform.position = transform.parent.position + _verticalOffset * Vector3.up;
		transform.rotation = Quaternion.identity;

		backdrop.position = backdrop.parent.position + _verticalOffset * Vector3.up;
		backdrop.rotation = Quaternion.identity;
	}
}
