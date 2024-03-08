using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class ShowCardDescription : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;

		public ShowCardDescription(Contexts contexts)
			: base(contexts.Get<Game>())
			=> _contexts = contexts;

		private UniqueComponentsContainer<Game> Unique => _contexts.Get<Game>().Unique;

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<TargetPosition>().Removed());

		protected override bool Filter(Entity<Game> entity)
			=> entity.Is<Lens>()
			   && !entity.Has<TargetPosition>()
			   && Unique.Has<Candidate>()
			   && _contexts.GetPlayer().Is<CurrentTurn>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var _ in entities)
			{
				var candidate = Unique.GetEntity<Candidate>();

				Debug.Log($"abilities of: {candidate}");
			}
		}
	}
}