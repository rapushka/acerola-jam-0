namespace Code
{
	public class ExitButton : ButtonBase
	{
		protected override void OnClick()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.ExitPlaymode();
#else
			UnityEngine.Application.Quit();
#endif
		}
	}
}