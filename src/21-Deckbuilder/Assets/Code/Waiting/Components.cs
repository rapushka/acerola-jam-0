using System;
using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Waiting : ValueComponent<float>, IInScope<Game> { }

	/// <summary> on `Waiting` component expired </summary>
	public sealed class Callback : ValueComponent<Action>, IInScope<Game> { }
}