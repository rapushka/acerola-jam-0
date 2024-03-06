using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class SpawnSides : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly BalanceConfig _balance;

		public SpawnSides(Contexts contexts, BalanceConfig balance)
		{
			_contexts = contexts;
			_balance = balance;
		}

		public void Initialize()
		{
			Spawn(Side.Player).Add<DebugName, string>("Player");
			Spawn(Side.Dealer).Add<DebugName, string>("Dealer").Is<Ai>(true);
		}

		private Entity<Game> Spawn(Side side)
		{
			var e = _contexts.Get<Game>().CreateEntity();
			e.Add<Component.Side, Side>(side);
			e.Add<Score, int>(0);
			e.Add<Money, int>(_balance.SideMoneyOnStart);
			return e;
		}
	}
}