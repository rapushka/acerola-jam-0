using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public abstract class EntityBehaviourBase<TScope> : EntityBehaviourBase
		where TScope : IScope
	{
		public abstract Entity<Game> Entity { get; }
	}
}