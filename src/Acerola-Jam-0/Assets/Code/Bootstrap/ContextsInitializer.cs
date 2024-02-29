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
			_contexts.InitializeScope<Scope.Game>();
		}

		private void InitializeIndexes()
		{
			// ID.Index.Initialize();
		}

		private void InitializeFormatters()
		{
#if UNITY_EDITOR
			// Entity<Scope.Game>.Formatter = new GameEntityFormatter();
#endif
		}
	}
}