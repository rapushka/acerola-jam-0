using Code.Component;
using Code.Scope;
using UnityEngine;

namespace Code
{
	[RequireComponent(typeof(Collider2D))]
	public class PressReceiver : MonoBehaviour
	{
		[SerializeField] private EntityBehaviourBase<Game> _behaviour;

		private bool IsPressed { set => _behaviour.Entity.Is<Pressed>(value); }

		private void OnMouseDown() => IsPressed = true;

		private void OnMouseUp() => IsPressed = false;
	}
}