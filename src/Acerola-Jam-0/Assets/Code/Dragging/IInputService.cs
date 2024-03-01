using UnityEngine;
using Zenject;

namespace Code
{
	public interface IInputService
	{
		Vector2 CursorWorldPoint { get; }
	}

	public class StandaloneInputService : IInputService
	{
		private readonly Camera _camera;

		[Inject] public StandaloneInputService(Camera camera) => _camera = camera;

		public Vector2 CursorWorldPoint => _camera.ScreenToWorldPoint(CursorScreenPoint);

		private static Vector3 CursorScreenPoint => Input.mousePosition;
	}
}