using Code.Component;
using Code.Scope;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class ContextsInitializer
	{
		private readonly Contexts _contexts;

		[Inject]
		public ContextsInitializer(Contexts contexts)
		{
			_contexts = contexts;

			InitializeScopes();
			InitializeIndexes();
			InitializeFormatters();
		}

		private void InitializeScopes()
		{
			_contexts.InitializeScope<Game>();
		}

		private void InitializeIndexes()
		{
			_contexts.Get<Game>().GetPrimaryIndex<Component.Side, Side>().Initialize();
			_contexts.Get<Game>().GetIndex<HeldBy, Side>().Initialize();
			_contexts.Get<Game>().GetIndex<Face, CardId>().Initialize();
			_contexts.Get<Game>().GetPrimaryIndex<ShadowCard, Side>().Initialize();
			_contexts.Get<Game>().GetPrimaryIndex<MoneyOf, Side>().Initialize();
		}

		private void InitializeFormatters()
		{
#if UNITY_EDITOR
			Entity<Game>.Formatter = new GameEntityFormatter();
#endif
		}
	}
}