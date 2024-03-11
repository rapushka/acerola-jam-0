using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code
{
	public sealed class SendBet : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly BetsFactory _factory;

		public SendBet(Contexts contexts, BetsFactory factory)
			: base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_factory = factory;
		}

		private Entity<Game> Bank => _contexts.Get<Game>().Unique.GetEntity<Bank>();

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<Money>());

		protected override bool Filter(Entity<Game> entity)
			=> entity.Has<Money>() && entity.Has<MoneyOf>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			if (Bank.Get<Money>().Value == 0)
				return;

			foreach (var e in entities)
				_factory.SendBet(from: e, to: Bank);
		}
	}
}