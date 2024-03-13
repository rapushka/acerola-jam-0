using Code.Component;
using Code.Scope;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class SidesFactory
	{
		private readonly Contexts _contexts;
		private readonly BetsFactory _betsFactory;
		private int _counter;

		[Inject]
		public SidesFactory(Contexts contexts, BetsFactory betsFactory)
		{
			_contexts = contexts;
			_betsFactory = betsFactory;
		}

		public Entity<Game> CreatePlayer()
			=> Create(Side.Player)
				.Add<DebugName, string>("Player");

		public Entity<Game> CreateDealer()
		{
			var e = Create(Side.Owneress)
			        .Add<DebugName, string>("Dealer")
			        .Add<DealerNumber, int>(_counter++)
			        .Is<Ai>(true);

			e.ReplaceMoney(_contexts.GetPlayer().GetMoney() * 2);
			return e;
		}

		private Entity<Game> Create(Side side)
		{
			var e = _contexts.Get<Game>().CreateEntity()
			                 .Add<Component.Side, Side>(side)
			                 .Add<Score, int>(0);

			_betsFactory.CreateMoneyOf(e);
			return e;
		}
	}
}