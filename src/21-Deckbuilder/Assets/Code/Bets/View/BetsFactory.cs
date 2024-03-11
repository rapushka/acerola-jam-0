using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using NotImplementedException = System.NotImplementedException;

namespace Code
{
	public class BetsFactory
	{
		private readonly IResourcesProvider _resource;
		private readonly HoldersProvider _holders;

		[Inject]
		public BetsFactory(IResourcesProvider resource, HoldersProvider holders)
		{
			_resource = resource;
			_holders = holders;
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
			=> e.Is<Bank>() ? _holders.Bank : _holders[e.Get<Component.Side>().Value].Money;
	}
}