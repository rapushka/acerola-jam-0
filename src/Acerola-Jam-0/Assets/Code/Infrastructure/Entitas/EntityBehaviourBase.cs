using Entitas.Generic;

namespace Code
{
	public abstract class EntityBehaviourBase<TScope> : EntityBehaviourBase
		where TScope : IScope
	{
		public abstract Entity<TScope> Entity { get; }
	}
}