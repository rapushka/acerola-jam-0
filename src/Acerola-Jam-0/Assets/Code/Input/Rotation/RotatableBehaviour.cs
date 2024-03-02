using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class RotatableBehaviour : DraggableBehaviour
	{
		[SerializeField] private BaseListener<Game, DeltaRotation> _rotationView;

		public override void Initialize()
		{
			base.Initialize();

			Entity
				.Is<Rotatable>(true)
				.Add<DeltaRotation, float>(0f)
				.AddListener(_rotationView)
				;
		}
	}
}