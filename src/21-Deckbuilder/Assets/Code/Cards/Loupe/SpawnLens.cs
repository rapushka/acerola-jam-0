using Code.Component;
using Entitas;
using UnityEngine;

namespace Code.System
{
	public sealed class SpawnLens : IInitializeSystem
	{
		private readonly IResourcesProvider _resources;
		private readonly HoldersProvider _holders;

		public SpawnLens(IResourcesProvider resources, HoldersProvider holders)
		{
			_resources = resources;
			_holders = holders;
		}

		public void Initialize()
		{
			var behaviour = _resources.SpawnLoupe(_holders.DefaultLens);
			behaviour.Entity.Add<Position, Vector3>(behaviour.transform.position);
			behaviour.Entity.Add<Rotation, Quaternion>(behaviour.transform.rotation);
		}
	}
}