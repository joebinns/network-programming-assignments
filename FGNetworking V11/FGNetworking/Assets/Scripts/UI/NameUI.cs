using UnityEngine;

public class NameUI : MonoBehaviour
{
	[SerializeField] private TextMesh _textMesh;
	[SerializeField] private Name _name;

	void Start()
	{
		_textMesh.text = _name.CurrentName.Value.ToString();
	}
}
