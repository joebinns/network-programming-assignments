using Unity.Collections;
using UnityEngine;

public class NameUI : MonoBehaviour
{
	[SerializeField] private TextMesh _textMesh;
	[SerializeField] private Name _name;

	void Start()
	{
		_name.CurrentName.OnValueChanged += UpdateUI;
	}

	private void UpdateUI(FixedString128Bytes previousValue, FixedString128Bytes newValue)
	{
		_textMesh.text = newValue;
	}
}
