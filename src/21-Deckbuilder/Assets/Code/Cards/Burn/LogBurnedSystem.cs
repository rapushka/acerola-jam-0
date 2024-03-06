using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class LogBurnedSystem : ReactiveSystem<Entity<Game>>
	{
		public LogBurnedSystem(Contexts contexts) : base(contexts.Get<Game>()) { }

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<Burned>().Added());

		protected override bool Filter(Entity<Game> entity) => entity.Is<Burned>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var e in entities)
				Debug.Log($"{e} is Burned!");
		}
	}
}