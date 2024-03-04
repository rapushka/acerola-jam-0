using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class WaitingSystem : IExecuteSystem
	{
		private readonly ITimeService _time;
		private readonly IGroup<Entity<Game>> _entities;

		public WaitingSystem(Contexts contexts, ITimeService time)
		{
			_time = time;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<Waiting>());
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var previousDuration = e.Get<Waiting>().Value;
				var newDuration = previousDuration - _time.DeltaTime;

				if (!(newDuration > 0f))
				{
					e.Remove<Waiting>();
					e.GetOrDefault<Callback>()?.Value.Invoke();
					e.RemoveSafety<Callback>();
					return;
				}

				e.Replace<Waiting, float>(newDuration);
			}
		}
	}
}