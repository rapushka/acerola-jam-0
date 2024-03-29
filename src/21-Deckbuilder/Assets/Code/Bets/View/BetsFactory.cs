using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class BetsFactory
	{
		private readonly IResourcesProvider _resource;
		private readonly HoldersProvider _holders;
		private readonly BalanceConfig _balance;
		private readonly ViewConfig _viewConfig;

		[Inject]
		public BetsFactory
		(
			IResourcesProvider resource,
			HoldersProvider holders,
			BalanceConfig balance,
			ViewConfig viewConfig
		)
		{
			_resource = resource;
			_holders = holders;
			_balance = balance;
			_viewConfig = viewConfig;
		}

		public void SendBet(Entity<Game> from, Entity<Game> to)
		{
			var startPoint = GetHolder(from);
			var endPoint = GetHolder(to);

			var view = _resource.SpawnBetView(startPoint);
			var entity = view.Entity;
			entity.Add<DebugName, string>("transaction");
			entity.Add<Position, Vector3>(view.transform.position);
			entity.Add<MovementSpeed, float>(_viewConfig.BetMovementSpeed);
			entity.Is<Transaction>(true);
			entity.SetTargetTransform(endPoint);
		}

		private Transform GetHolder(Entity<Game> e)
			=> e.Is<Bank>() ? _holders.Bank : _holders[e.Get<MoneyOf>().Value].Money;

		public void CreateMoneyOf(Entity<Game> entity)
		{
			var side = entity.Get<Component.Side>().Value;
			var heap = _resource.SpawnMoneyHeapView(_holders[side].Money).Entity;
			heap.Add<DebugName, string>($"Money of {side}");
			heap.Add<MoneyOf, Side>(side);
			heap.Add<Money, int>(_balance.SideMoneyOnStart);
		}

		public void CreateBank()
		{
			var bank = _resource.SpawnMoneyHeapView(_holders.Bank).Entity;
			bank.Add<DebugName, string>("bank");
			bank.Is<Bank>(true);
			bank.Add<MinBet, int>(_balance.MinBetOnStart);
			bank.Add<CurrentBet, int>(_balance.MinBetOnStart);
			bank.Add<Money, int>(0);
		}
	}
}