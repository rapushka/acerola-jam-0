using Code.Component;
using Code.Scope;
using UnityEngine;

namespace Code
{
	public class ActualPositionReceiver : MonoBehaviour
	{
		[SerializeField] private EntityBehaviourBase<Game> _behaviour;
		[SerializeField] private Rigidbody2D _rigidbody2D;

		private void FixedUpdate()
		{
			_behaviour.Entity.Replace<ActualPosition, Vector2>(_rigidbody2D.position);
		}
	}
}