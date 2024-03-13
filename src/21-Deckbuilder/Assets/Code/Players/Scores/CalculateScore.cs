using Entitas;

namespace Code.System
{
	public sealed class CalculateScore : IExecuteSystem
	{
		private readonly CalculateScoreCommand _command;

		public CalculateScore(CalculateScoreCommand command)
		{
			_command = command;
		}

		public void Execute()
		{
			_command.Do();
		}
	}
}