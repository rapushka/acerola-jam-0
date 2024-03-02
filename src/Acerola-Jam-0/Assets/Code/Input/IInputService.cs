using UnityEngine;
using Zenject;

namespace Code
{
	public interface IInputService
	{
		Vector2 CursorWorldPoint { get; }

		bool RotateLeft  { get; }
		bool RotateRight { get; }
	}

	public class StandaloneInputService : IInputService
	{
		private readonly Camera _camera;

		[Inject] public StandaloneInputService(Camera camera) => _camera = camera;

		public Vector2 CursorWorldPoint => _camera.ScreenToWorldPoint(CursorScreenPoint);

		public bool RotateLeft  => Input.GetKey(KeyCode.Q);
		public bool RotateRight => Input.GetKey(KeyCode.E);

		private static Vector3 CursorScreenPoint => Input.mousePosition;
	}
}