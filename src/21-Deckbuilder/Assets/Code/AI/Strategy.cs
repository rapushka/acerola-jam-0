using System;

namespace Code
{
	public class Strategy
	{
		public float Benefit = 0;
		public Action Action;

		public Strategy(Action action)
		{
			Action = action;
		}
	}
}