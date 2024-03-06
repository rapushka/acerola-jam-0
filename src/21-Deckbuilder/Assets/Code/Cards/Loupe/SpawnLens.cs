using Code.Component;
using Entitas;
using UnityEngine;

namespace Code.System
{
	public sealed class SpawnLens : IInitializeSystem
	{
		private readonly IResourcesProvider _resources;
		private readonly HoldersProvider _holders;
		private readonly ViewConfig _viewConfig;

		public SpawnLens(IResourcesProvider resources, HoldersProvider holders, ViewConfig viewConfig)
		{
			_resources = resources;
			_holders = holders;
			_viewConfig = viewConfig;
		}

		public void Initialize()
		{
			var behaviour = _resources.SpawnLoupe(_holders.DefaultLens);
			behaviour.Entity.Add<DebugName, string>("Magnifying Glass");
			behaviour.Entity.Add<Position, Vector3>(behaviour.transform.position);
			behaviour.Entity.Add<Rotation, Quaternion>(behaviour.transform.rotation);
			behaviour.Entity.Replace<MovementSpeed, float>(_viewConfig.MagnifyingGlassSpecificSpeed);
		}
	}
}