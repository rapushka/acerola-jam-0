using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class TranslatePositionFromLensToReflection : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _lenses;
		private readonly IGroup<Entity<Game>> _reflections;

		public TranslatePositionFromLensToReflection(Contexts contexts)
		{
			_lenses = contexts.GetGroup(Get<Lens>());
			_reflections = contexts.GetGroup(Get<Component.Reflection>());
		}

		public void Execute()
		{
			foreach (var lens in _lenses)
			foreach (var reflection in _reflections)
				reflection.Replace(lens.Get<Position>());
		}
	}
}