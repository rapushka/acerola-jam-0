using System;
using UnityEngine;

namespace Code
{
	public class ReflectionView : MonoBehaviour
	{
		[SerializeField] private MeshFilter _meshFilter;

		private void Start()
		{
			var mesh = new Mesh();

			var vertexes = new Vector3[5];
			var uv = new Vector2[5];
			var triangles = new int[6];

			var step = 1f;
			vertexes[0] = new Vector3(0, -step);
			vertexes[1] = new Vector3(0, step);
			vertexes[2] = new Vector3(step, 0);
			vertexes[3] = new Vector3(step * 2, step);
			vertexes[4] = new Vector3(step * 2, -step);

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

			mesh.vertices = vertexes;
			mesh.uv = uv;
			mesh.triangles = triangles;

			_meshFilter.mesh = mesh;
		}
	}
}