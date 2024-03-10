using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class LampBehaviour : ComponentBehaviourBase<Game>
	{
		[Inject] private readonly HoldersProvider _holders;
		[Inject] private readonly ViewConfig _viewConfig;

		public override void Add(ref Entity<Game> entity)
		{
			entity.Is<Lamp>(true);
			entity.Add<DebugName, string>("lamp");
			entity.Add<Rotation, Quaternion>(_holders.Lamp.Default.rotation);
			entity.Add<RotationSpeed, float>(_viewConfig.LampRotationSpeed);
		}
	}
}