using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code.System
{
	public sealed class DropDraggable : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _entities;

		[Inject]
		public DropDraggable(Contexts contexts)
		{
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<Dropped>());
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				e.Is<Pressed>(false);
				e.Replace<Position, Vector2>(e.Get<ActualPosition>().Value);
			}
		}
	}
}