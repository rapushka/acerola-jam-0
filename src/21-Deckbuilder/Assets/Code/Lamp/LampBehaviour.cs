using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class LampBehaviour : ComponentBehaviourBase<Game>
	{
		public override void Add(ref Entity<Game> entity)
		{
			entity.Is<Lamp>(true);
			entity.Add<DebugName, string>("lamp");
			entity.Add<Rotation, Quaternion>(transform.rotation);
		}
	}
}