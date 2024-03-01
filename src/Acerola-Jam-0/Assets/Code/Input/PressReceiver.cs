using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	[RequireComponent(typeof(Collider2D))]
	public class PressReceiver : MonoBehaviour
	{
		[SerializeField] private EntityBehaviourBase<Game> _behaviour;

		private Entity<Game> Entity => _behaviour.Entity;

		private void OnMouseDown() => Entity.Is<Pressed>(true);

		private void OnMouseUp() => Entity.Is<Dropped>(true);
	}
}