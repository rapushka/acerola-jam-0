using UnityEngine.SceneManagement;

namespace Code
{
	public class ToMainMenuButton : ButtonBase
	{
		protected override void OnClick() => SceneManager.LoadScene("Scenes/Main Menu Scene");
	}
}