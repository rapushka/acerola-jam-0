using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class GameEntityFormatter : EntityComponentsListFormatter<Game>
	{
		protected override IEnumerable<string> CreateList(Entity<Game> entity)
		{
			yield return entity.creationIndex.ToString();

			yield return entity.ToString<DebugName, string>(defaultValue: "e");

			yield return entity.ToString<Face, CardId>();

			yield return entity.ToString<Money, int>();
			yield return entity.ToString<Waiting, float>(prefix: "timer: ", postfix: "s");

			yield return entity.Is<CurrentTurn>() ? "<- current" : string.Empty;
		}
	}
}