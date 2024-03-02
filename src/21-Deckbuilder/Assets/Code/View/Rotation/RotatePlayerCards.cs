using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code
{
	public sealed class RotatePlayerCards : ReactiveSystem<Entity<Game>>
	{
		private readonly ViewConfig _viewConfig;

		public RotatePlayerCards(Contexts contexts, ViewConfig viewConfig)
			: base(contexts.Get<Game>())
		{
			_viewConfig = viewConfig;
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<HeldBy>());

		protected override bool Filter(Entity<Game> entity)
			=> entity.Get<HeldBy>().Value is Side.Player && entity.Has<Rotation>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var e in entities)
				e.Replace<TargetRotation, Quaternion>(_viewConfig.RotationToPlayer.AsEuler());
		}
	}
}