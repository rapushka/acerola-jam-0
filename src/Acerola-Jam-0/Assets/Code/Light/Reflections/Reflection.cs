using UnityEngine;

namespace Code
{
	public class Reflection : MonoBehaviour
	{
		[SerializeField] private MeshFilter _meshFilter;
		[SerializeField] private GameConfig _gameConfig;

		[Header("Options")]
		[SerializeField] private float _maxRayDistance;
		[SerializeField] private float _radius;

		private Vector3[] _vertexes;
		private Mesh _mesh;

		private void Start()
		{
			_mesh = new Mesh();

			_vertexes = new Vector3[5];
			var uv = new Vector2[5];
			var triangles = new int[6];

			uv[0] = new Vector2(0, 0);
			uv[1] = new Vector2(0, 1);
			uv[2] = new Vector2(0.5f, 0.5f);
			uv[3] = new Vector2(1, 1);
			uv[4] = new Vector2(1, 0);

			triangles[0] = 0;
			triangles[1] = 1;
			triangles[2] = 2;

			triangles[3] = 2;
			triangles[4] = 3;
			triangles[5] = 4;

			_mesh.vertices = _vertexes;
			_mesh.uv = uv;
			_mesh.triangles = triangles;

			_meshFilter.mesh = _mesh;
		}

		public void UpdateVertexes(Vector3 vectorToLight)
		{
			_vertexes[0] = new Vector3(0, -_radius);
			_vertexes[1] = new Vector3(0, _radius);

			var principleFocus = vectorToLight.magnitude * _gameConfig.Physics.LensPrincipleFocus;
			_vertexes[2] = Quaternion.Inverse(transform.rotation) * vectorToLight.normalized * principleFocus;

			var fromUpToBottom = (_vertexes[2] - _vertexes[0]).normalized;
			_vertexes[3] = fromUpToBottom * _maxRayDistance + _vertexes[2];

			var fromBottomToTop = (_vertexes[2] - _vertexes[1]).normalized;
			_vertexes[4] = fromBottomToTop * _maxRayDistance + _vertexes[2];

			_mesh.vertices = _vertexes;
		}
	}
}