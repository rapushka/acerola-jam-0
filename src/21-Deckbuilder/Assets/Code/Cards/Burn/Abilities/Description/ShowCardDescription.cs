using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class ShowCardDescription : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly HudMediator _hud;
		private readonly DescriptionBuilder _descriptionBuilder;

		public ShowCardDescription(Contexts contexts, HudMediator hud, DescriptionBuilder descriptionBuilder)
			: base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_hud = hud;
			_descriptionBuilder = descriptionBuilder;
		}

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
				var description = _descriptionBuilder.Build(candidate);
				_hud.CardDescription.Show(description);
			}
		}
	}
}