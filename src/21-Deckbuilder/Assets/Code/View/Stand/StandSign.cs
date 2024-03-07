using TMPro;
using UnityEngine;

namespace Code
{
	public class StandSign : MonoBehaviour
	{
		[SerializeField] private Color _disabledColor;
		[SerializeField] private Color _enabledColor;
		[SerializeField] private TMP_Text _textMesh;

		public bool TurnedOn { set => _textMesh.color = value ? _enabledColor : _disabledColor; }
	}
}