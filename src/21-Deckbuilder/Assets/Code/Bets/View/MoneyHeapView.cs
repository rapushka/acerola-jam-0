using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class MoneyHeapView : ComponentBehaviourBase<Game>
	{
		public override void Add(ref Entity<Game> entity)
		{
			entity.Add<DebugName, string>("money heap");
		}
	}
}