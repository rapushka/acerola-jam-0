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

		[Inject]
		public BetsFactory(IResourcesProvider resource, HoldersProvider holders, BalanceConfig balance)
		{
			_resource = resource;
			_holders = holders;
			_balance = balance;
		}

		public void SendBet(Entity<Game> from, Entity<Game> to)
		{
			var startPoint = GetHolder(from);
			var endPoint = GetHolder(to);

			var bet = _resource.SpawnBetView(startPoint).Entity;
			bet.Add<DebugName, string>("transaction");
			bet.Is<Transaction>(true);
			bet.SetTargetTransform(endPoint);
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
	}
}