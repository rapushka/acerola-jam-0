using Code.System;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class MainFeature : InjectableFeature
	{
		[Inject]
		public MainFeature(Contexts contexts, SystemsFactory factory)
			: base(nameof(MainFeature), factory)
		{
			Add<RegisterBehavioursSystem>();

			// Dragging
			Add<DropDraggableOnMouseTooFar>();
			Add<Drag>();

			Add<BoilerplateFeature>();
		}
	}
}