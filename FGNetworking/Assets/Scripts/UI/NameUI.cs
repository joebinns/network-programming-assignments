using UnityEngine;

public class NameUI : MonoBehaviour
{
	[SerializeField] private TextMesh _textMesh;
	[SerializeField] private Name _name;
	[SerializeField, Range(0f, 1f)] private float _verticalOffset = 0.6f;

	private void Start()
	{
		_textMesh.text = _name.UserName.Value.ToString();
	}

	private void Update()
	{
		transform.position = transform.parent.position + _verticalOffset * Vector3.up;
		transform.rotation = Quaternion.identity;
	}
}
