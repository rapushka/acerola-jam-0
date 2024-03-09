using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class CancelBurnOfUnBurnableCard : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly HudMediator _hud;
		private readonly IGroup<Entity<Game>> _entities;

		public CancelBurnOfUnBurnableCard(Contexts contexts, HudMediator hud)
		{
			_contexts = contexts;
			_hud = hud;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<BurnCandidate>());
		}

		private Entity<Game> Side      => _contexts.Get<Game>().Unique.GetEntity<CurrentTurn>();
		private Entity<Game> Candidate => _contexts.Get<Game>().Unique.GetEntity<Candidate>();

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				if (Candidate.Is<CanNotBeBurn>())
				{
					e.Is<BurnCandidate>(false);
					e.Is<Destroyed>(false);

					if (Side.IsPlayer())
						_hud.Message.ShowError("This card can't be Burn!");
				}
			}
		}
	}
}