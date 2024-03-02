using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class CalculateVectorToLightSource : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _reflections;
		private readonly IGroup<Entity<Game>> _lightSources;

		[Inject]
		public CalculateVectorToLightSource(Contexts contexts)
		{
			_reflections = contexts.GetGroup(Get<Component.Reflection>());
			_lightSources = contexts.GetGroup(Get<LightSource>());
		}

		public void Execute()
		{
			foreach (var lightSource in _lightSources)
			foreach (var e in _reflections)
			{
				var vectorToLens = e.Get<Position>().Value - lightSource.Get<Position>().Value;
				e.Replace<VectorFromLight, Vector2>(vectorToLens);
			}
		}
	}
}