using System;
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

			if (entity.Has<Face>() && entity.Has<Suit>())
			{
				var face = entity.ToString<Face, CardFace>();
				yield return face.Replace("Number", string.Empty);
				yield return "of";
				yield return entity.ToString<Suit, CardSuit>();
			}

			yield return entity.ToString<Money, int>();

			yield return entity.Is<CurrentTurn>() ? "<- current" : string.Empty;
		}
	}
}