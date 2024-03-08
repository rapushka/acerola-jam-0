using Code.Component;
using Code.Scope;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class SidesFactory
	{
		private readonly Contexts _contexts;
		private readonly BalanceConfig _balance;
		private int _counter;

		[Inject]
		public SidesFactory(Contexts contexts, BalanceConfig balance)
		{
			_contexts = contexts;
			_balance = balance;
		}

		public Entity<Game> CreatePlayer()
			=> Create(Side.Player)
				.Add<DebugName, string>("Player");

		public Entity<Game> CreateDealer()
			=> Create(Side.Dealer)
			   .Add<DebugName, string>("Dealer")
			   .Add<DealerNumber, int>(0)
			   .Is<Ai>(true);

		private Entity<Game> Create(Side side)
			=> _contexts.Get<Game>().CreateEntity()
			            .Add<Component.Side, Side>(side)
			            .Add<Score, int>(_counter++)
			            .Add<Money, int>(_balance.SideMoneyOnStart);
	}
}