using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using EndDeal = Code.Component.EndDeal;

namespace Code
{
	public sealed class CheckBankruptcy : ReactiveSystem<Entity<Game>>
	{
		private readonly BalanceConfig _balance;
		private readonly HudMediator _hud;
		private readonly IGroup<Entity<Game>> _sides;

		public CheckBankruptcy(Contexts contexts, BalanceConfig balance, HudMediator hud)
			: base(contexts.Get<Game>())
		{
			_balance = balance;
			_hud = hud;
			_sides = contexts.GetGroup(ScopeMatcher<Game>.Get<Component.Side>());
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<EndDeal>().Added());

		protected override bool Filter(Entity<Game> entity) => entity.Is<EndDeal>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var side in _sides)
			{
				if (side.GetMoney() >= _balance.MinBetOnStart)
					continue;

				var isDealerBankrupt = side.Get<Component.Side>().Value is Side.Owneress;
				if (isDealerBankrupt)
				{
					side.Is<Bankrupt>(true); // TODO: or how?
					_hud.ShowWinScreen();
				}
				else
				{
					side.Is<Bankrupt>(true); // TODO: or how?
					_hud.ShowLooseScreen();
				}
			}
		}
	}
}