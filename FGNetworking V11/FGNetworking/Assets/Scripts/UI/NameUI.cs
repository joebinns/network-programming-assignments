using UnityEngine;

public class NameUI : MonoBehaviour
{
	[SerializeField] private TextMesh _textMesh;
	[SerializeField] private Name _name;

	void Start()
	{
		_name.CurrentName.OnValueChanged += UpdateUI;
	}

	private void UpdateUI(string previousValue, string newValue)
	{
		_textMesh.text = newValue;
	}
}
