using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code.System
{
	public sealed class BurnCard : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _entities;

		public BurnCard(Contexts contexts)
		{
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<ToBurn>());
		}

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				e.Is<ToBurn>(false);
				e.Is<Burned>(true);

				Debug.Log($"{e} is Burned!");
			}
		}
	}
}