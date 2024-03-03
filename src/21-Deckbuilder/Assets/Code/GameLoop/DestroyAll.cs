using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class DestroyAll : ITearDownSystem
	{
		private readonly Contexts _contexts;

		public DestroyAll(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void TearDown()
		{
			_contexts.Get<Game>().DestroyAllEntities();
		}
	}
}