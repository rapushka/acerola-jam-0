using UnityEngine;

namespace Code
{
	public interface ITimeService
	{
		float DeltaTime     { get; }
		float RealDeltaTime { get; }
	}

	public class TimeService : ITimeService
	{
		public float DeltaTime     => Time.deltaTime;
		public float RealDeltaTime => Time.unscaledDeltaTime;
	}
}