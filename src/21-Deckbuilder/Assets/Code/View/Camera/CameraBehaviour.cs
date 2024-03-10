using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using Camera = Code.Component.Camera;

namespace Code
{
	public class CameraBehaviour : ComponentBehaviourBase<Game>
	{
		[Inject] private readonly ViewConfig _viewConfig;

		[SerializeField] private UnityEngine.Camera _camera;

		public override void Add(ref Entity<Game> entity)
		{
			entity.Add<Camera, UnityEngine.Camera>(_camera);
			entity.Add<DebugName, string>("Camera");
			entity.Add<Position, Vector3>(transform.position);
			entity.Add<Rotation, Quaternion>(transform.rotation);
			entity.Add<RotationSpeed, float>(_viewConfig.CameraRotationSpeed);
			entity.Add<MovementSpeed, float>(_viewConfig.CameraMovementSpeed);
		}
	}
}